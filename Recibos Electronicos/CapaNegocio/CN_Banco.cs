using CapaEntidad;
using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace CapaNegocio
{
    public class CN_Banco
    {
        public void ObtenerBitacora( ref List<BancoBitacora> lbb, string fecha_i, string fecha_f, string Ejercicio, string Mes/*, string Fecha_Pago*/ )
        {
            CD_Banco cd_banco = new CD_Banco();
            cd_banco.ObtenerBitacora(ref lbb, ref fecha_i, ref fecha_f, Ejercicio, Mes/*, Fecha_Pago*/);
        }
        public IDictionary<string, string> CargarArchivo(HttpPostedFile archivo)
        {
            Banco banco = new Banco();
            BancoBitacora bitacora = new BancoBitacora();
            CD_Banco cd_banco = new CD_Banco();
            
            String linea = "";
            String bandera = "0";
            IDictionary<string, string> salida = new Dictionary<string, string>();
            UInt16 total = 0;
            UInt16 num_linea = 1;
            Byte exito_lectura = 1;

            salida["exito"] = "1";
            salida["mensaje"] = "";

            System.IO.StreamReader archivo_ap = new System.IO.StreamReader(archivo.InputStream);

            while ((linea = archivo_ap.ReadLine()) != null)
            {
                exito_lectura = banco.AgregarDatos(linea);

                if (exito_lectura == 1)
                {
                    bitacora.Banco_nombre = banco.Nombre;
                    bitacora.Fecha_pago = banco.Fecha;

                    cd_banco.InsertarPagado(ref banco, ref bandera);

                    if (bandera == "0" || bandera == "-1" || bandera == "")
                        ++total;

                    else
                        salida["mensaje"] += $"<li>Ocurrió un problema al guardar el registro en la línea <b>{num_linea}</b> del archivo. Código de error: <b>{bandera}</b></li>";
                }
                else if( exito_lectura == 2 )
                {
                    salida["mensaje"] += "<li>Referencia inválida "+banco.Referencia.Substring( 0, banco.Referencia.Length - 2 )+"</li>";
                }

                ++num_linea;

            }

            if (total > 0)
            {
                archivo_ap.DiscardBufferedData();
                archivo_ap.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);

                bitacora.Archivo_nombre = archivo.FileName;
                bitacora.Total_registros = total;
                bitacora.Archivo_contenido = archivo_ap.CurrentEncoding.GetBytes( archivo_ap.ReadToEnd() );

                cd_banco.InsertarBitacora(ref bitacora, ref bandera);

                if (bandera != "0" && bandera != "")
                    salida["mensaje"] += $"<li>Ocurrió un error al guardar la bitacora. Código de error: <b>{bandera}</b></li>";

                if (salida["mensaje"].Length > 0)
                {
                    salida["exito"] = "0";
                    salida["mensaje"] = $"Se guardaron <b>{total}</b> registro(s) de <b>{banco.Nombre}</b> pero se omitieron los siguientes registros: <ul>{salida["mensaje"]}</ul>";
                }

                else
                {
                    salida["exito"] = "1";
                    salida["mensaje"] = $"Se guardaron <b>{total}</b> registro(s) de <b>{banco.Nombre}</b>";
                }
            }

            else
            {
                salida["exito"] = "0";
                salida["mensaje"] = "No se guardó ningun registro, compruebe que sea un archivo válido";
            }

            archivo_ap.Close();

            return salida;
        }
        public IDictionary<string, string> CargarArchivoCaja(HttpPostedFile archivo)
        {
            Banco banco = new Banco();
            BancoBitacora bitacora = new BancoBitacora();
            CD_Banco cd_banco = new CD_Banco();

            String linea = "";
            String bandera = "0";
            String bandera_eliminar = "0";
            IDictionary<string, string> salida = new Dictionary<string, string>();
            UInt16 total = 0;
            UInt16 num_linea = 1;
            Byte exito_lectura = 1;

            salida["exito"] = "1";
            salida["mensaje"] = "";

            System.IO.StreamReader archivo_ap = new System.IO.StreamReader(archivo.InputStream);
            cd_banco.EliminarPagadoCaja(ref bandera_eliminar);
            if (bandera_eliminar == "1")
            {
                while ((linea = archivo_ap.ReadLine()) != null)
                {
                    exito_lectura = banco.AgregarDatosCaja(linea);

                    if (exito_lectura == 1)
                    {
                        cd_banco.InsertarPagadoCaja(ref banco, ref bandera);
                        if (bandera == "0" || bandera == "-1" || bandera == "")
                            ++total;

                        else
                            salida["mensaje"] += $"<li>Ocurrió un problema al guardar el registro en la línea <b>{num_linea}</b> del archivo. Código de error: <b>{bandera}</b></li>";
                    }
                    else if (exito_lectura == 2)
                    {
                        salida["mensaje"] += "<li>Referencia inválida " + banco.Referencia.Substring(0, banco.Referencia.Length - 2) + "</li>";
                    }

                    ++num_linea;

                }


                if (total > 0)
                {
                    archivo_ap.DiscardBufferedData();
                    archivo_ap.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);

                    bitacora.Archivo_nombre = archivo.FileName;
                    bitacora.Total_registros = total;
                    bitacora.Archivo_contenido = archivo_ap.CurrentEncoding.GetBytes(archivo_ap.ReadToEnd());

                    //cd_banco.InsertarBitacora(ref bitacora, ref bandera);

                    if (bandera != "0" && bandera != "")
                        salida["mensaje"] += $"<li>Ocurrió un error al guardar la bitacora. Código de error: <b>{bandera}</b></li>";

                    if (salida["mensaje"].Length > 0)
                    {
                        salida["exito"] = "0";
                        salida["mensaje"] = $"Se guardaron <b>{total}</b> registro(s) de <b>{banco.Nombre}</b> pero se omitieron los siguientes registros: <ul>{salida["mensaje"]}</ul>";
                    }

                    else
                    {
                        salida["exito"] = "1";
                        salida["mensaje"] = $"Se guardaron <b>{total}</b> registro(s) de <b>{banco.Nombre}</b>";
                    }
                }

                else
                {
                    salida["exito"] = "0";
                    salida["mensaje"] = "No se guardó ningun registro, compruebe que sea un archivo válido";
                }

                archivo_ap.Close();

            }
            else
            {
                salida["exito"] = "0";
                salida["mensaje"] = "No se pudo cargar correctamente los datos, compruebe que sea un archivo válido";
            }
            return salida;

        }

        public void ConsultarArchivo(ref BancoBitacora ObjBanco)
        {
            try
            {
                CD_Banco CDBanco = new CD_Banco();
                CDBanco.ConsultarArchivo(ref ObjBanco);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
