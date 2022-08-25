<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Banco.aspx.cs" Inherits="Recibos_Electronicos.Banco" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        input[type='file'] {
            width: 90%;
        }

        .mgg_cuadro {
            width: 80%;
            border: 1px solid #c5c5c5;
            border-radius: 8px;
            margin: auto;
            margin-top: 15px;
        }

        .mgg_aviso {
            padding: 12px 15px 12px 15px;
            box-sizing: border-box;
            min-height: 40px;
            font-size: 10.5pt;
            display: block;
            border-top-left-radius: 8px;
            border-top-right-radius: 8px;
        }

        .mgg_aviso_verde {
            color: #3c763d;
            background-color: #dff0d8;
            border: 1px dotted #d6e9c6;
        }

        .mgg_aviso_azul {
            background-color: #d9edf7;
            border: 1px dotted #bce8f1;
            color: #31708f;
        }

        .mgg_aviso_rojo {
            background-color: #f7d9d9;
            border: 1px dotted #f1bcbc;
            color: #d15b47;
        }

        .mgg_aviso ul {
            list-style-type: disc;
            margin-left: 30px;
            margin-top: 10px;
        }

        .mgg_linea {
            width: 100%;
            min-height: 30px;
            margin-top: 8px;
            margin-bottom: 8px;
        }

            .mgg_linea .mgg_col-gd-3 {
                display: inline-block;
                width: 29%;
            }

            .mgg_linea .mgg_col-gd-4 {
                display: inline-block;
                width: 39%;
            }

        .mgg_enviar {
            border: none;
            color: white;
            height: 100%;
            padding: 7px 25px 7px 25px;
            background-color: #0098cb;
            cursor: pointer;
        }

        .mgg_tabla {
            width: 80%;
            margin: auto;
            text-align: center;
            border: 1px solid #c5c5c5;
        }

            .mgg_tabla td {
                padding: 10px 5px 10px 5px;
            }

            .mgg_tabla tbody tr:first-child {
                background-color: #d6e9c6;
                color: #3c763d;
                height: 30px;
            }

        #div_spinner {
            width: 100%;
            text-align: center;
            display: none;
        }
    </style>
    <script type="text/javascript">
        function mostrar_spinner() {
            document.getElementById("div_control").style.display = "none";
            document.getElementById("div_spinner").style.display = "block";
        }

        function LoadTXT(valor) {
            //alert(valor);
            valor = '../ArchivosBanco/' + valor;
            window.open(valor, '',
                'scrollbars=no,menubar=no,height=600,width=800,resizable=yes,toolbar=no,location=no,status=no');
        }
    </script>
    <script src="../Scripts/DataTables/jquery.dataTables.min.js"></script>
    <link href="../Content/DataTables/css/jquery.dataTables.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col mgg_cuadro">
                <asp:Label ID="Label1" runat="server" Text="Label" CssClass="mgg_aviso mgg_aviso_verde">Puede subir cualquier archivo bancario: Banamex, Banorte, Santander, Bancomer Ventanilla, Bancomer Multipagos</asp:Label>
            </div>
        </div>
        <div class="row">
            <div class="col-md-2">Archivo</div>
            <div class="col-md-8">
                <asp:FileUpload ID="FileUpload1" runat="server" />
                <div id="div_spinner">
                    <img src="../Imagenes/ajax-loader2.gif" alt="" />
                </div>
            </div>
            <div class="col-md-2">
                <asp:Button ID="Button1" runat="server" Text="Subir" OnClick="Enviar_Click" CssClass="mgg_enviar" OnClientClick="mostrar_spinner( )" />
            </div>
        </div>
        <div class="row">
            <div class="col text-center">
                <asp:UpdateProgress ID="UpdateProgress2" runat="server"
                    AssociatedUpdatePanelID="UpdatePanel1">
                    <ProgressTemplate>
                        <asp:Image ID="Image86" runat="server"
                            AlternateText="Espere un momento, por favor.." Height="50px"
                            ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif"
                            ToolTip="Espere un momento, por favor.." />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </div>
        <div class="row">
            <div class="col-md-2">Ejercicio</div>
            <div class="col-md-2">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlEjercicio" runat="server" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="ddlEjercicio_SelectedIndexChanged">
                            <asp:ListItem>2022</asp:ListItem>
                            <asp:ListItem>2021</asp:ListItem>
                            <asp:ListItem>2020</asp:ListItem>
                            <asp:ListItem>2019</asp:ListItem>
                            <asp:ListItem>2018</asp:ListItem>
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>            
            <div class="col-md-2">
                <asp:UpdateProgress ID="updEjercicio" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
                    <ProgressTemplate>
                        <asp:Image ID="imgEjercicio" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
            <div class="col-md-2">Mes</div>
            <div class="col-md-2">
                <asp:DropDownList ID="ddlMes" runat="server" Width="100%" onChange="Mes()">
                    <asp:ListItem Value="00">TODOS</asp:ListItem>
                    <asp:ListItem Value="01">ENERO</asp:ListItem>
                    <asp:ListItem Value="02">FEBRERO</asp:ListItem>
                    <asp:ListItem Value="03">MARZO</asp:ListItem>
                    <asp:ListItem Value="04">ABRIL</asp:ListItem>
                    <asp:ListItem Value="05">MAYO</asp:ListItem>
                    <asp:ListItem Value="06">JUNIO</asp:ListItem>
                    <asp:ListItem Value="07">JULIO</asp:ListItem>
                    <asp:ListItem Value="08">AGOSTO</asp:ListItem>
                    <asp:ListItem Value="09">SEPTIEMBRE</asp:ListItem>
                    <asp:ListItem Value="10">OCTUBRE</asp:ListItem>
                    <asp:ListItem Value="11">NOVIEMBRE</asp:ListItem>
                    <asp:ListItem Value="12">DICIEMBRE</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>

        <div class="row">
            <div class="col">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="GVBitacora" runat="server" EmptyDataText="No hay registros" AutoGenerateColumns="False" CssClass="mGrid" Width="100%" OnSelectedIndexChanged="GVBitacora_SelectedIndexChanged">
                            <Columns>
                                <asp:BoundField DataField="Id" HeaderText="ID" />
                                <asp:BoundField DataField="Banco_nombre" HeaderText="Banco" />
                                <asp:BoundField DataField="Archivo_nombre" HeaderText="Nombre del archivo" />
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:Label ID="Label4" runat="server" Text="Fecha de pago"></asp:Label>
                                        <%-- <asp:DropDownList ID="ddlFechaPago" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlFechaPago_SelectedIndexChanged" AppendDataBoundItems="True">
                                        </asp:DropDownList>--%>
                                    </HeaderTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Fecha_registro" HeaderText="Fecha de carga" />
                                <asp:BoundField DataField="Total_registros" HeaderText="Total" />
                                <asp:CommandField SelectText="Descargar Archivo" ShowSelectButton="True" />
                                <asp:BoundField DataField="Ejercicio" />
                                <asp:BoundField DataField="Mes" />
                            </Columns>
                            <FooterStyle CssClass="enc" />
                            <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                            <SelectedRowStyle CssClass="sel" />
                            <HeaderStyle CssClass="enc" />
                            <AlternatingRowStyle CssClass="alt" />
                        </asp:GridView>
                        <br />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <script type="text/javascript">    
        <%--$(document).ready(function () {
            $('#<%= GVBitacora.ClientID %>').DataTable({
                initComplete: function () {
                    this.api().columns().every(function () {
                        var column = this;
                        var select = $('<select><option value=""></option></select>')
                            .appendTo($(column.footer()).empty())
                            .on('change', function () {
                                var val = $.fn.dataTable.util.escapeRegex(
                                    $(this).val()
                                );

                                column
                                    .search(val ? '^' + val + '$' : '', true, false)
                                    .draw();
                            });

                        column.data().unique().sort().each(function (d, j) {
                            select.append('<option value="' + d + '">' + d + '</option>')
                        });
                    });
                }
            });
        });--%>
        function Bitacora() {
            $('#<%= GVBitacora.ClientID %>').prepend($("<thead></thead>").append($('#<%= GVBitacora.ClientID %>').find("tr:first"))).DataTable({
                "destroy": true,
                "stateSave": true,
                "ordering": false
            });
        };

        function Mes() {
            var table = $('#<%= GVBitacora.ClientID %>').DataTable();   
            var selectedValue = $('#<%= ddlMes.ClientID %>').val();            
            if (selectedValue != "00") {
                table.columns(8).search(selectedValue).draw();
            }
            else {
                table.columns(8).search("").draw();
            }
        }
    </script>
</asp:Content>
