<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Facturas.ascx.cs" Inherits="Recibos_Electronicos.ControlUsuario.Facturas" %>
<style type="text/css">

           
 * {
				margin:0px;
				padding:0px;
             
	}

 

.mGrid {  
    margin: 5px 0 5px 0;  
    font-family:Arial;
     border: solid 1px #D9D9D9; /* borde de al redededor del grid*/

     z-index:1;
 
}  

  
    .mGrid .enc {     /*paginado*/
        color:red;
 
        font-size:12px;
        text-transform:uppercase;

         text-align:center;

        background: rgba(226,226,226,1);
background: -moz-linear-gradient(top, rgba(226,226,226,1) 0%, rgba(219,219,219,1) 50%, rgba(209,209,209,1) 51%, rgba(254,254,254,1) 100%);
background: -webkit-gradient(left top, left bottom, color-stop(0%, rgba(226,226,226,1)), color-stop(50%, rgba(219,219,219,1)), color-stop(51%, rgba(209,209,209,1)), color-stop(100%, rgba(254,254,254,1)));
background: -webkit-linear-gradient(top, rgba(226,226,226,1) 0%, rgba(219,219,219,1) 50%, rgba(209,209,209,1) 51%, rgba(254,254,254,1) 100%);
background: -o-linear-gradient(top, rgba(226,226,226,1) 0%, rgba(219,219,219,1) 50%, rgba(209,209,209,1) 51%, rgba(254,254,254,1) 100%);
background: -ms-linear-gradient(top, rgba(226,226,226,1) 0%, rgba(219,219,219,1) 50%, rgba(209,209,209,1) 51%, rgba(254,254,254,1) 100%);
background: linear-gradient(to bottom, rgba(226,226,226,1) 0%, rgba(219,219,219,1) 50%, rgba(209,209,209,1) 51%, rgba(254,254,254,1) 100%);
filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#e2e2e2', endColorstr='#fefefe', GradientType=0 );


    }  
  
        .auto-style91 {
            width: 61px;
        }
        
  select
{
   padding:3px 6px 3px 6px;
   min-height:30px;
   font-size:13px;
      
    border-radius:4px;
    border:solid 1px #ccc;

 z-index:1;
}

         
      option {
        font-weight: normal;
        background-color:#fff;
    }
      
    

.btn4{

  -webkit-border-radius: 1;
  -moz-border-radius: 1;
  border-radius: 1px;

  font-family: Arial;
  color: #FFF;
  font-size: 13px;
 background: #0098CB;
  padding: 7px 12px 7px 10px;
  border:1px solid #D9D9D9;
   border-radius:4px;
  text-decoration: none;

  transition: all 0.8s ease;



  
   

}


.btn4{

padding:3px 6px 3px 6px;
 
   min-height:24px;
   font-size:13px;

background: rgba(255,255,255,1);
background: -moz-linear-gradient(top, rgba(255,255,255,1) 0%, rgba(246,246,246,1) 47%, rgba(239,239,239,1) 52%, rgba(237,237,237,1) 53%);
background: -webkit-gradient(left top, left bottom, color-stop(0%, rgba(255,255,255,1)), color-stop(47%, rgba(246,246,246,1)), color-stop(52%, rgba(239,239,239,1)), color-stop(53%, rgba(237,237,237,1)));
background: -webkit-linear-gradient(top, rgba(255,255,255,1) 0%, rgba(246,246,246,1) 47%, rgba(239,239,239,1) 52%, rgba(237,237,237,1) 53%);
background: -o-linear-gradient(top, rgba(255,255,255,1) 0%, rgba(246,246,246,1) 47%, rgba(239,239,239,1) 52%, rgba(237,237,237,1) 53%);
background: -ms-linear-gradient(top, rgba(255,255,255,1) 0%, rgba(246,246,246,1) 47%, rgba(239,239,239,1) 52%, rgba(237,237,237,1) 53%);
background: linear-gradient(to bottom, rgba(255,255,255,1) 0%, rgba(246,246,246,1) 47%, rgba(239,239,239,1) 52%, rgba(237,237,237,1) 53%);
filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#ffffff', endColorstr='#ededed', GradientType=0 );

border:none;
border-radius:4px;

}

    .mGrid .alt {  
      background:#F2F2F2; /*  td alternado */
    }  
  
      .mGrid a{
      color:#0098CB;
    text-decoration:none;
}
  
    a{
    color:#0098CB;
    text-decoration:none;
}

    .auto-style94 {
        width: 121px;
    }
    .auto-style95 {
        width: 67px;
    }
    .auto-style97 {
        width: 231px;
    }
    .auto-style98 {
        width: 103px;
    }
    .auto-style99 {
        width: 45px;
    }
</style>

<table style="width:100%;">
    <tr>
        <td>
            <table style="width:100%;">
                <tr>
                    <td class="auto-style94" valign="top">
                                                        <asp:Label ID="lblFecha_Factura_Ini" runat="server" Text="Fecha Inicial:"></asp:Label>
                                                    </td>
                    <td class="auto-style95" valign="top">
                                                        <asp:TextBox ID="txtFecha_Factura_Ini" runat="server" CssClass="box" MaxLength="10" Width="95px"></asp:TextBox>
                                                        <ajaxToolkit:CalendarExtender ID="txtFecha_Factura_Ini_CalendarExtender" runat="server" PopupButtonID="imgCalendarioIni" TargetControlID="txtFecha_Factura_Ini" />
                                                    </td>
                    <td class="auto-style97" valign="top">
                                                        <asp:ImageButton ID="imgCalendarioIni" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                                                    </td>
                    <td class="auto-style98" valign="top">
                                                        <asp:Label ID="lblFecha_Factura_Fin" runat="server" Text="Fecha Final:"></asp:Label>
                                                    </td>
                    <td class="auto-style99" valign="top">
                                                        <asp:TextBox ID="txtFecha_Factura_Fin" runat="server" CssClass="box" MaxLength="10" Width="95px"></asp:TextBox>
                                                        <ajaxToolkit:CalendarExtender ID="txtFecha_Factura_Fin_CalendarExtender" runat="server" PopupButtonID="imgCalendarioFin" TargetControlID="txtFecha_Factura_Fin" />
                                                    </td>
                    <td valign="top">
                                                        <asp:ImageButton ID="imgCalendarioFin" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                                                    </td>
                    <td valign="top">
                                                                                                                <asp:ImageButton ID="imgBttnBuscar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png" OnClick="imgBttnBuscar_Click" />
                                                    </td>
                </tr>
                </table>
        </td>
    </tr>
    <tr>
        <td>
                                                                                        <asp:GridView ID="grdDatosFactura" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="3" CssClass="mGrid" DataKeyNames="Id_Fact" EmptyDataText="No existen facturas, para el rango de fecha especificado..." OnPageIndexChanging="grdDatosFactura_OnPageIndexChanging" OnSelectedIndexChanged="grdDatosFactura_SelectedIndexChanged" PageSize="15" Width="100%" OnRowDataBound="grdDatosFactura_RowDataBound">
                                                                                            <Columns>
                                                                                                <asp:BoundField DataField="Id_Fact" HeaderText="Id_Fact" SortExpression="ID" />
                                                                                                <asp:BoundField DataField="FACT_FOLIO" HeaderText="Folio" SortExpression="FOLIO">
                                                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                                                </asp:BoundField>
                                                                                                <asp:BoundField DataField="FACT_REFERENCIA" HeaderText="Referencia" SortExpression="REFERENCIA">
                                                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                                                </asp:BoundField>
                                                                                                <asp:BoundField DataField="FACT_FECHA_FACTURA" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha" SortExpression="FECHA_FACTURA">
                                                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                                                </asp:BoundField>
                                                                                                <asp:BoundField DataField="FACT_TOTAL" DataFormatString="{0:c}" HeaderText="Importe" ItemStyle-HorizontalAlign="Right" SortExpression="Importe">
                                                                                                    <HeaderStyle HorizontalAlign="Right" />
                                                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                                                </asp:BoundField>
                                                                                                <asp:BoundField DataField="FACT_CLIENTE" HeaderText="Nombre">
                                                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                                                </asp:BoundField>
                                                                                                <asp:BoundField DataField="FACT_NOMBRE" HeaderText="Beneficiario Factura" SortExpression="NOMBRE">
                                                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                                                </asp:BoundField>
                                                                                                <asp:BoundField DataField="FACT_DEPENDENCIA" HeaderText="Depen." SortExpression="DEPENDENCIA">
                                                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                                                </asp:BoundField>
                                                                                                <asp:BoundField DataField="FACT_BANCO" HeaderText="Banco" />
                                                                                                <asp:TemplateField HeaderText="ENVIAR XML/PDF">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:ImageButton ID="imgBttnCorreo" runat="server" ImageUrl="https://sysweb.unach.mx/resources/Imagenes/correo2.png" OnClick="imgBttnCorreo_Click" />
                                                                                                    </ItemTemplate>
                                                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                                </asp:TemplateField>
                                                                                                <asp:BoundField DataField="ID_FICHA_BANCARIA" />
                                                                                                <asp:TemplateField HeaderText="VER RECIBO">
                                                                                                    <ItemTemplate>
                                                                                                        <asp:ImageButton ID="imgBttnRecibo" runat="server" ImageUrl="https://sysweb.unach.mx/resources/Imagenes/recibo2.png" OnClick="imgBttnRecibo_Click" />
                                                                                                    </ItemTemplate>
                                                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                                </asp:TemplateField>                                                                            
                                                                                                <asp:BoundField DataField="FACT_TIPO" />                                                                                                
                                                                                                <asp:TemplateField HeaderText="VER XML/PDF">
                                                                                                    <ItemTemplate>
                                                                                                        <table style="width: 100%;">
                                                                                                            <tr>
                                                                                                                <td class="auto-style91">
                                                                                                                    <asp:DropDownList ID="ddlFacturas" runat="server">
                                                                                                                        <asp:ListItem Value="0">Elegir</asp:ListItem>
                                                                                                                        <asp:ListItem Value="1">PDF</asp:ListItem>
                                                                                                                        <asp:ListItem Value="2">XML</asp:ListItem>
                                                                                                                    </asp:DropDownList>
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <asp:Button ID="bttnVerFactura" runat="server" CssClass="btn4" OnClick="bttnVerFactura_Click" Text="Ver" />
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </table>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                            </Columns>
                                                                                            <FooterStyle CssClass="enc" />
                                                                                            <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                                                            <SelectedRowStyle CssClass="sel" />
                                                                                            <HeaderStyle CssClass="enc" />
                                                                                            <AlternatingRowStyle CssClass="alt" />
                                                                                        </asp:GridView>
                                                                                    </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
    </tr>
</table>

