<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmFacturas3.aspx.cs" Inherits="Recibos_Electronicos.Form.FrmFacturas3" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<%@ Register Src="../EnviarCorreo.ascx" TagName="uccorreo" TagPrefix="usr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Scripts/DataTables/jquery.dataTables.min.js"></script>
    <link href="../Content/DataTables/css/jquery.dataTables.min.css" rel="stylesheet" />
    <script type="text/javascript">



        function callprogress(vValor) {
            //vValor = vValor + 40;
            document.getElementById("getProgressBarFill").style.width = vValor + '%';
            document.getElementById("getProgressBarFill").innerHTML = vValor + '%';
        };

        function LoadPDF(ruta) {
            //valor = '../Facturas/PDF/' + valor + '.pdf';
            alert("paso");
            window.open(ruta, '_blank');
        };

        function LoadXML(valor) {
            valor = '../Facturas/XML/' + valor + '.xml';
            window.open(valor, '',
                'scrollbars=no,menubar=no,height=600,width=800,resizable=yes,toolbar=no,location=no,status=no');
        };

        function LoadPDF_Nuevo(valor) {
            alert("pasa");
            valor = '../Facturas/PDF/' + valor;
            window.open(valor, '',
                'scrollbars=no,menubar=no,height=600,width=800,resizable=yes,toolbar=no,location=no,status=no');
        };

        function LoadXML_Nuevo(valor) {
            //alert(valor);
            valor = '../Facturas/XML/' + valor;
            window.open(valor, '',
                'scrollbars=no,menubar=no,height=600,width=800,resizable=yes,toolbar=no,location=no,status=no');
        }

        function ValidateTipoPersona(sender, args) {
            var tipoPers = document.getElementById('<%=ddlTipoPers.ClientID %>');

            if (tipoPers.value == "F") {
                if (document.getElementById('<%=txtReceptor_Rfc.ClientID %>').value.length == "13") {
                    args.IsValid = true;
                }
                else {

                    args.IsValid = false;
                }
            }
            else {
                if (document.getElementById('<%=txtReceptor_Rfc.ClientID %>').value.length == "12") {
                    args.IsValid = true;
                }
                else {
                    args.IsValid = false;
                }
            }

        };



        function ValidateCheckBox(sender, args) {

            if (document.getElementById('<%=chkConfirmaSolicitud.ClientID %>').checked == true) {
                args.IsValid = true;
            } else {
                args.IsValid = false;
            }
        };

        function ValidateIvaDeposito(sender, args) {
            if (document.getElementById('<%=chkIvaDes.ClientID %>').checked == true) {
                args.IsValid = true;
            } else {
                args.IsValid = false;
            }
        }


    </script>
    <style type="text/css">
        table th {
            font-size: 0.7rem;
            font-weight: 400;
            /* color: #474747; */
        }
        /* Ahora creo el estilo que hara que aparesca el porcentanje y relleno del mismoo*/
        .ProgressBar { /*height: 1.25em; display: block; width:85%*/
            overflow: hidden;
            height: 20px;
            margin-bottom: 20px;
            background-color: #f5f5f5;
            border-radius: 4px;
            -webkit-box-shadow: inset 0 1px 2px rgba(0,0,0,.1);
            box-shadow: inset 0 1px 2px rgba(0,0,0,.1);
            width: 85%;
        }

        #getProgressBarFill {
            height: 100%;
            width: 0%;
            background-color: #428bca;
            display: block;
            text-align: center;
            color: #ffffff;
        }

        .RadGrid_Silk {
            border-color: #d9d9d9;
            color: #333;
            background-color: #fff;
        }

        .rgCommandCell {
            border-color: #c4c4c4;
            color: #5f5f5f;
            background-color: #e3e3e3;
            background-image: linear-gradient(white,#e3e3e3);
            border-width: 1px;
            padding: 4px;
            border-style: solid;
        }

        .t-button {
            background: none transparent;
            border: 1px solid transparent;
            padding: 4px;
            color: inherit;
        }

        .accordionCabecera {
            border: 1px solid black;
            background-color: #5a7c9d;
            /*#5078B3;*/
            border-color: #a0a0a0;
            /*#bbb;*/
            font-family: Calibri;
            font-size: 14px;
            font-weight: bold;
            padding: 5px;
            margin-top: 4px;
            cursor: pointer;
            background-image: url("../Imagenes/ico-accordion.png");
            background-repeat: no-repeat;
            background-position: right;
            color: #fff
        }

            .accordionCabecera a:hover {
                background-color: #505050;
                /*#428bca;*/
                text-decoration: underline;
            }

        .accordionContenido {
            font-family: Sans-Serif;
            background-color: #fff;
            border: 1px solid #dcdcdc;
            font-size: 12px;
            padding: 7px;
        }

        .accordionHeaderSelected {
            border: 1px solid black;
            background-color: #dcdcdc;
            border-color: #dcdcdc;
            font-family: Calibri;
            font-size: 14px;
            font-weight: bold;
            padding: 5px;
            margin-top: 4px;
            cursor: pointer;
        }

            .accordionHeaderSelected img {
                display: none;
            }

            .accordionHeaderSelected img2 {
                display: block;
            }

        .cssHeaderSelected {
            background-color: #505050;
            border: 1px solid #d5e6ff;
            color: white;
            cursor: pointer;
            font-family: Arial,Sans-Serif;
            font-size: 14px;
            font-weight: bold;
            margin-top: 5px;
            padding: 5px;
            padding-right: 10px;
            width: 100%;
            background-image: url(../Imagenes/minus.png);
            background-repeat: no-repeat;
            background-position: right;
        }


        .input-group-text_buscar {
            display: -ms-flexbox;
            display: flex;
            -ms-flex-align: center;
            align-items: center;
            margin-bottom: 0;
            font-size: 1rem;
            font-weight: 400;
            line-height: 1.5;
            color: #495057;
            text-align: center;
            white-space: nowrap;
            background-color: #4285f4;
            border: 1px solid #ced4da;
            border-radius: .25rem;
        }



        .tabstyle .ajax__tab_header {
            font-size: 13px;
            font-weight: bold;
            color: #000;
            font-family: sans-serif;
        }

            .tabstyle .ajax__tab_active .ajax__tab_inner, .tabstyle .ajax__tab_header .ajax__tab_inner, .tabstyle .ajax__tab_hover .ajax__tab_inner {
                height: 46px;
                margin-left: 16px;
            }

            .tabstyle .ajax__tab_active .ajax__tab_tab, .tabstyle .ajax__tab_hover .ajax__tab_tab, .tabstyle .ajax__tab_header .ajax__tab_tab {
                margin: 16px 16px 0px 0px;
            }

        .tabstyle .ajax__tab_active .ajax__tab_outer {
            border-left: solid 1px #999999;
            border-top: solid 1px #999999;
            border-right: solid 1px #999999;
            background-color: #d7d7d7;
            font-weight: bold;
            border-style: outset;
        }

        .tabstyle .ajax__tab_body {
            font-family: Arial;
            font-size: 10pt;
            border-top: 0;
            border: 1px solid #999999;
            padding: 8px;
            background-color: #ffffff;
        }

        .ajax__tab_xp .ajax__tab_body {
            background-color: #ffffff;
            border: 1px solid #999999;
            border-top: 0;
            font-family: Arial;
            font-size: 11pt;
            padding: 8px;
        }

        fa fa-cloud-upload

        .accordion {
            width: 400px;
        }

        .btn {
            display: inline-block;
            font-size: 14px;
            font-weight: 400;
            line-height: 1.42857143;
            text-align: center;
            white-space: nowrap;
            vertical-align: middle;
            cursor: pointer;
            user-select: none;
            background-image: none;
            border: 1px solid transparent;
            border-radius: 4px;
        }


        .btn-app {
            color: white;
            box-shadow: none;
            border-radius: 3px;
            position: relative;
            padding: 10px 15px;
            margin: 0;
            min-width: 40px;
            max-width: 60px;
            text-align: center;
            border: 1px solid #ddd;
            background-color: #f4f4f4;
            font-size: 10px;
            transition: all .2s;
            background-color: steelblue !important;
        }

            .btn-app > .fa, .btn-app > .glyphicon, .btn-app > .ion {
                font-size: 20px;
                display: block;
            }

            .btn-app:hover {
                border-color: #aaa;
                transform: scale(1.1);
            }

        .pdf {
            background-color: #5e5e5e !important;
            /*background-color: #dc2f2f !important;*/
        }

        .excel {
            background-color: #3ca23c !important;
        }

        .csv {
            background-color: #e86c3a !important;
        }

        .input-group-text {
            display: -ms-flexbox;
            display: flex;
            -ms-flex-align: center;
            align-items: center;
            padding: 0.2rem 0.6rem;
            margin-bottom: 0;
            font-size: 1rem;
            font-weight: 400;
            line-height: 1.5;
            color: #495057;
            text-align: center;
            white-space: nowrap;
            background-color: #7d858d;
            border: 1px solid #ced4da;
            border-radius: 0.25rem;
        }


        table.dataTable thead th, table.dataTable thead td {
            padding: 10px 2px 10px 2px;
            border-bottom: 1px solid #111;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container-fluid">
        <div class="row">
            <div class="col text-center">
                <asp:UpdateProgress ID="UpdateProgress4" runat="server" AssociatedUpdatePanelID="UpdatePanel11">
                    <ProgressTemplate>
                        <div class="overlay">
                            <div class="overlayContent">
                                <asp:Image ID="img1" runat="server" Height="100px" ImageUrl="~/Imagenes/loader2.gif" Width="100px" />
                            </div>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </div>
    </div>
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <asp:MultiView ID="mltViewFacturas" runat="server">
                <asp:View ID="Datos" runat="server">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col">
                                <div class="note note-warning" style="font-size: 14px">
                                    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                        <ContentTemplate>
                                            <asp:Label ID="lblNota" runat="server" Text=""></asp:Label>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2">
                                Dependencia
                            </div>
                            <div class="col-md-10">
                                <asp:DropDownList ID="ddlDependencia" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                            </div>

                        </div>
                        <div class="row">
                            <div class="col-md-2">
                                Tipo
                            </div>
                            <div class="col-md-2">
                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlTipo" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlTipo_SelectedIndexChanged" AutoPostBack="True">
                                            <asp:ListItem Value="R">Referenciado</asp:ListItem>
                                            <asp:ListItem Value="T">Efectivo/Transferencia</asp:ListItem>
                                            <asp:ListItem Value="A">Facturas Anticipadas</asp:ListItem>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-md-1" runat="server" id="rowFiltro1">
                                Filtro
                            </div>
                            <div class="col-md-3" runat="server" id="rowFiltro2">
                                <asp:DropDownList ID="ddlFiltro" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="S">Recibos con solicitud de factura</asp:ListItem>
                                    <asp:ListItem Value="T">Todos los recibos</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-1">
                                Status
                            </div>
                            <div class="col-md-3">
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlStatus" runat="server" Width="100%" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged" AutoPostBack="True" CssClass="btn btn-primary dropdown-toggle browser-default custom-select custom-select-lg mb-3">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2">
                                <asp:UpdatePanel ID="UpdatePanel14" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lblEtFormaBusqueda" runat="server" Text="Pago del" Font-Bold="True"></asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtFecha_Factura_Ini" runat="server" Width="80%"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="txtFecha_Factura_Ini_CalendarExtender" runat="server" PopupButtonID="imgCalendarioIni" TargetControlID="txtFecha_Factura_Ini" />
                                <asp:ImageButton ID="imgCalendarioIni" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                            </div>
                            <div class="col-md-2 font-weight-bold">
                                al               
                                <asp:TextBox ID="txtFecha_Factura_Fin" runat="server" Width="70%"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="txtFecha_Factura_Fin_CalendarExtender" runat="server" PopupButtonID="imgCalendarioFin" TargetControlID="txtFecha_Factura_Fin" />
                                <asp:ImageButton ID="imgCalendarioFin" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                            </div>
                            <div class="col-md-4">
                                <asp:TextBox ID="txtReferencia" runat="server" CssClass="form-control" PlaceHolder="Referencia/Nombre"></asp:TextBox>
                                <%--<div class="input-group-append">
                                    <span class="input-group-text_buscar" id="basic-addon2">
                                        <asp:LinkButton ID="linkBttnBuscar" runat="server" class="btn-buscar btn-primary" OnClick="linkBttnBuscar_Click" Width="30px"><i class="fa fa-search" aria-hidden="true"></i></asp:LinkButton>                                       
                                    </span>
                                </div>--%>
                            </div>

                            <div class="col-md-2">
                                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                    <ContentTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-grey" OnClick="linkBttnBuscar_Click" Width="100%"><i class="fa fa-file"></i> Ver Recibos</asp:LinkButton>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>



                        </div>
                        <div class="col">
                            <asp:RequiredFieldValidator ID="reqDep" runat="server" ControlToValidate="ddlDependencia" InitialValue="00000" ValidationGroup="New" Text="* Seleccionar Dependencia" ErrorMessage="* Seleccionar Dependencia"></asp:RequiredFieldValidator>
                        </div>

                        <asp:MultiView ID="mltViewTipo" runat="server">
                            <asp:View ID="View1" runat="server">
                                <div class="row">
                                    <div class="col">
                                        <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                            <ContentTemplate>
                                                <asp:GridView ID="grdDatosFactura" runat="server" AutoGenerateColumns="False" CellPadding="3" CssClass="mGrid table table-striped table-bordered table-hover" DataKeyNames="Id_Fact" EmptyDataText="No existen facturas, para el rango de fecha especificado..." OnSelectedIndexChanged="grdDatosFactura_SelectedIndexChanged" PageSize="15" Width="100%" OnRowDeleting="grdDatosFactura_RowDeleting" ShowHeaderWhenEmpty="True">
                                                    <Columns>
                                                        <asp:BoundField DataField="Id_Fact" HeaderText="Id_Fact" SortExpression="ID"></asp:BoundField>
                                                        <asp:BoundField DataField="FACT_FOLIO" HeaderText="Folio" SortExpression="FOLIO">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="Referencia" SortExpression="REFERENCIA">
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("FACT_REFERENCIA") %>'></asp:TextBox>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("FACT_REFERENCIA") %>' ToolTip='<%# Bind("TOOLTIP") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="FACT_TOTAL" DataFormatString="{0:C}" HeaderText="Importe" ItemStyle-HorizontalAlign="Right" SortExpression="Importe">
                                                            <HeaderStyle HorizontalAlign="Right" />
                                                            <ItemStyle HorizontalAlign="Right" Font-Bold="True" Font-Size="12px" />
                                                            <ControlStyle Width="30px" />
                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="Nombre">
                                                            <EditItemTemplate>
                                                                <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("FACT_CLIENTE") %>'></asp:TextBox>
                                                            </EditItemTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblNombre" runat="server" Text='<%# Bind("FACT_CLIENTE") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="FACT_NOMBRE" HeaderText="Beneficiario Factura" SortExpression="NOMBRE">
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="FACT_DEPENDENCIA" HeaderText="Depen" SortExpression="DEPENDENCIA">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="FACT_BANCO" HeaderText="Banco">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="FACT_FECHA_FACTURA" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha Factura" SortExpression="FECHA_FACTURA">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="FACT_FECHA_SOLICITUD" HeaderText="Fecha Status">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="# Dias Status">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label2" runat="server" Text='<%# Bind("FACT_DIAS_SOLICITUD") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Status">
                                                            <HeaderTemplate>
                                                                <asp:Label ID="lblLeyStatus" runat="server" Text="STATUS"></asp:Label>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSol" runat="server" Text='<%# Bind("FACT_DESC_STATUS_SOLICITUD") %>' Font-Bold="True" Font-Size="8"></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="linkBttnBitacora" runat="server" OnClick="linkBttnBitacoraRef_Click" ToolTip="Bitacora"><i class="fa fa-clock-o fa-2x" aria-hidden="true"></i></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Editar">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="linkBttnEditar" runat="server" CausesValidation="false" CommandName="Select" ToolTip="Actualizar datos fiscales"><i aria-hidden="true" class="fa fa-pencil fa-2x"></i></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" Width="20px" Wrap="False" />
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="linkBttnCancelar" runat="server" CausesValidation="false" CommandName="Delete" OnClientClick="return confirm('¿Desea eliminar el registro?');"><i class="fa fa-trash fa-2x" aria-hidden="true"></i></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <ControlStyle Width="20px" />
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="FACT_RECEPTOR_CORREO" />
                                                        <asp:TemplateField HeaderText="Enviar Doctos">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="linkBttnCorreo" runat="server" OnClick="linkBttnCorreo_Click" ToolTip="Enviar facturas por correo"><i class="fa fa-envelope fa-2x" aria-hidden="true"></i></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="ID_FICHA_BANCARIA" />
                                                        <asp:BoundField DataField="FACT_STATUS_CAJA" />
                                                        <asp:BoundField DataField="FACT_RECEPTOR_STATUS" />
                                                        <asp:TemplateField HeaderText="Ver Recibo">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="linkBttnRecibo" runat="server" OnClick="linkBttnRecibo_Click" ToolTip="Comprobante oficial"><i class="fa fa-file-pdf-o fa-2x" aria-hidden="true"></i></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="RECHAZADO">
                                                            <ItemTemplate>
                                                                <asp:Image ID="imgRechazado2" runat="server" ImageUrl='<%# Bind("Ruta_Pdf") %>' />
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="FACT_TIPO" />
                                                        <asp:TemplateField HeaderText="Ver Doctos">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="linkBttnFacturaRef" runat="server" CausesValidation="false" OnClick="linkBttnFacturaRef_Click" ToolTip="Archivos adjuntos"><i aria-hidden="true" class="fa fa-cloud-download fa-2x"></i></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="FACT_DIAS_SOLICITUD" />
                                                        <asp:BoundField DataField="FACT_RECEPTOR_STATUS2" />
                                                        <asp:BoundField DataField="COLOR" />
                                                        <asp:TemplateField HeaderText="Solicitar Cancelación">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="linkBttnCancelarFact1" runat="server" CausesValidation="false" ToolTip="Eliminar registro" OnClick="linkBttnEliminarStatus_Click"><i class="fa fa-times-circle fa-2x" aria-hidden="true"></i></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <FooterStyle CssClass="enc" />
                                                    <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                    <SelectedRowStyle CssClass="sel" />
                                                    <HeaderStyle CssClass="enc" Font-Size="12px" />
                                                    <AlternatingRowStyle CssClass="alt" />
                                                </asp:GridView>
                                                <asp:GridView ID="grdDatosFacturaEfect" runat="server" AutoGenerateColumns="False" CellPadding="3" CssClass="mGrid table table-striped table-bordered table-hover" DataKeyNames="Id_Fact" EmptyDataText="No existen facturas, para el rango de fecha especificado..." OnSelectedIndexChanged="grdDatosFacturaEfect_SelectedIndexChanged" ShowHeaderWhenEmpty="True" Width="100%" OnRowDeleting="grdDatosFacturaEfect_RowDeleting">
                                                    <Columns>
                                                        <asp:BoundField DataField="ID_FACT" HeaderText="Id_Fact" SortExpression="ID" />
                                                        <asp:BoundField DataField="DEPENDENCIA" HeaderText="Depen" SortExpression="DEPENDENCIA">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="RECEPTOR_RFC" HeaderText="RFC" />
                                                        <asp:BoundField DataField="RECEPTOR_NOMBRE" HeaderText="Beneficiario Factura" SortExpression="NOMBRE">
                                                            <HeaderStyle HorizontalAlign="Left" />
                                                            <ItemStyle HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="NUM_OFICIO" HeaderText="# Oficio" />
                                                        <asp:BoundField DataField="FECHA_OFICIO" HeaderText="Fecha Oficio" />
                                                        <asp:BoundField DataField="FOLIO_PAGO" HeaderText="Folio Pago" SortExpression="FOLIO">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="FECHA_PAGO" HeaderText="Fecha Pago" />
                                                        <asp:BoundField DataField="IMPORTE_PAGO" DataFormatString="{0:C}" ItemStyle-HorizontalAlign="Right" HeaderText="Importe Pago">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="IVA_PAGO" DataFormatString="{0:C}" HeaderText="IVA Pago" ItemStyle-HorizontalAlign="Right" SortExpression="Importe">
                                                            <ItemStyle HorizontalAlign="Right" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="TOTAL_PAGO" DataFormatString="{0:C}" ItemStyle-HorizontalAlign="Right" HeaderText="Total Pago">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="IMPORTE_CONVENIO" HeaderText="Importe Convenio" />
                                                        <asp:BoundField DataField="IVA_CONVENIO" HeaderText="Iva Convenio" />
                                                        <asp:BoundField DataField="TOTAL_CONVENIO" HeaderText="Total Convenio" />
                                                        <asp:BoundField DataField="FECHA_REP" HeaderText="Fecha REP" />
                                                        <asp:BoundField DataField="FOLIO_REP" HeaderText="Folio REP" />
                                                        <asp:BoundField DataField="RECEPTOR_FECHA_STATUS" HeaderText="Fecha Status">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="# Dias Status">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Label4" runat="server" Text='<%# Bind("DIAS_SOLICITUD") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Status">
                                                            <HeaderTemplate>
                                                                <asp:LinkButton ID="linkBttnAgregarReg0" runat="server" CssClass="btn btn-dark" OnClientClick="LimpiarCampos();" OnClick="linkBttnAgregarReg_Click" ValidationGroup="New">Nuevo</asp:LinkButton>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblSol0" runat="server" Font-Bold="True" Font-Size="8" Text='<%# Bind("DESC_RECEPTOR_STATUS") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle ForeColor="#000000" HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Bitacora">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="linkBttnBitacora0" runat="server" OnClick="linkBttnBitacora_Click" ToolTip="Bitacora"><i aria-hidden="true" class="fa fa-clock-o fa-2x"></i></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Doctos">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="linkBttnEditar0" runat="server" CausesValidation="false" CommandName="Select" Visible='false' ToolTip="Actualizar datos fiscales"><i aria-hidden="true" class="fa fa-pencil fa-2x"></i></asp:LinkButton>
                                                                <asp:LinkButton ID="linkBttnFactura" runat="server" CausesValidation="false" OnClick="linkBttnFactura_Click" ToolTip="Archivos adjuntos"><i aria-hidden="true" class="fa fa-cloud-download fa-2x"></i></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" Width="20px" Wrap="False" />
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="linkBttnCancelar0" runat="server" CausesValidation="false" CommandName="Delete" OnClientClick="return confirm('¿Desea eliminar el registro?');" ToolTip="Eliminar registro"><i aria-hidden="true" class="fa fa-trash fa-2x"></i></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <ControlStyle Width="20px" />
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="RECEPTOR_CORREO" />
                                                        <asp:TemplateField HeaderText="ENVIAR XML/PDF">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="linkBttnCorreo0" runat="server" OnClick="linkBttnCorreo_Click" ToolTip='Enviar facturas por correo'><i aria-hidden="true" class="fa fa-envelope fa-2x"></i></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="RECEPTOR_STATUS" />
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="linkBttnRecibo0" runat="server" OnClick="linkBttnRecibo_Click" ToolTip="Comprobante fiscal"><i aria-hidden="true" class="fa fa-sticky-note fa-2x"></i></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="RECHAZADO">
                                                            <ItemTemplate></ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="TIPO" />
                                                        <asp:BoundField DataField="COLOR" />
                                                        <asp:TemplateField HeaderText="Editar">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="linkBttnEditar2" runat="server" CausesValidation="false" CommandName="Select" ToolTip="Actualizar datos fiscales"><i aria-hidden="true" class="fa fa-pencil fa-2x"></i></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Solicitar Cancelación">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="linkBttnEliminarStatus" runat="server" CausesValidation="false" ToolTip="Eliminar registro" OnClick="linkBttnEliminarStatus_Click"><i aria-hidden="true" class="fa fa-times-circle fa-2x"></i></asp:LinkButton>
                                                            </ItemTemplate>
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <FooterStyle CssClass="enc" />
                                                    <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                    <SelectedRowStyle CssClass="sel" />
                                                    <HeaderStyle CssClass="enc" Font-Size="12px" />
                                                    <AlternatingRowStyle CssClass="alt" />
                                                </asp:GridView>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </asp:View>
                            <asp:View ID="View2" runat="server">
                            </asp:View>
                        </asp:MultiView>
                    </div>
                    <asp:DropDownList ID="ddlAvance" runat="server" Visible="False">
                    </asp:DropDownList>
                    <asp:HiddenField ID="hddnBandera" runat="server" />
                </asp:View>
                <asp:View ID="Reporte" runat="server">
                    <table style="width: 100%;">
                        <tr>
                            <td align="center" colspan="3">
                                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="btnRegresar" runat="server" CssClass="btn btn-blue-grey" Height="40px"
                                            OnClick="btnRegresar_Click" Text="REGRESAR" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:UpdateProgress ID="UpdateProgress2" runat="server"
                                    AssociatedUpdatePanelID="UpdatePanel3">
                                    <ProgressTemplate>
                                        <asp:Image ID="Image86" runat="server"
                                            AlternateText="Espere un momento, por favor.." Height="50px"
                                            ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif"
                                            ToolTip="Espere un momento, por favor.." />
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <iframe id="miniContenedor" frameborder="0" marginheight="0" marginwidth="0"
                                            name="miniContenedor" style="height: 500px" width="100%"></iframe>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="Facturas" runat="server">
                    <div class="container-fluid">
                        <!-- Horizontal Steppers -->
                        <div class="row" id="rowPaso1" runat="server" visible="false">
                            <div class="col">
                                <!-- Stepers Wrapper -->
                                <ul class="stepper stepper-horizontal">

                                    <!-- First Step -->
                                    <li class="active">
                                        <a href="#!">
                                            <span class="circle">1</span>
                                            <span class="label">Registrar y confirmar solicitud</span>
                                        </a>
                                    </li>

                                    <!-- Second Step -->
                                    <li>
                                        <a href="#!">
                                            <span class="circle">2</span>
                                            <span class="label">Adjuntar Factura</span>
                                        </a>
                                    </li>

                                    <!-- Third Step -->
                                    <li>
                                        <a href="#!">
                                            <span class="circle">3</span>
                                            <span class="label">Adjuntar Comprobante de Pago</span>
                                        </a>
                                    </li>

                                    <li>
                                        <a href="#!">
                                            <span class="circle">4</span>
                                            <span class="label">REP</span>
                                        </a>
                                    </li>

                                    <li>
                                        <a href="#!">
                                            <span class="circle">5</span>
                                            <span class="label">Documentación completa</span>
                                        </a>
                                    </li>

                                </ul>
                                <!-- /.Stepers Wrapper -->

                            </div>
                        </div>
                        <div class="row" id="rowPaso2" runat="server" visible="false">
                            <div class="col">
                                <!-- Stepers Wrapper -->
                                <ul class="stepper stepper-horizontal">

                                    <!-- First Step -->
                                    <li class="completed">
                                        <a href="#!">
                                            <span class="circle">1</span>
                                            <span class="label">Registrar y confirmar solicitud</span>
                                        </a>
                                    </li>

                                    <!-- Second Step -->
                                    <li class="active">
                                        <a href="#!">
                                            <span class="circle">2</span>
                                            <span class="label">Adjuntar Factura</span>
                                        </a>
                                    </li>

                                    <!-- Third Step -->
                                    <li class="active">
                                        <a href="#!">
                                            <span class="circle">3</span>
                                            <span class="label">Adjuntar Comprobante de Pago</span>
                                        </a>
                                    </li>

                                    <li>
                                        <a href="#!">
                                            <span class="circle">4</span>
                                            <span class="label">REP</span>
                                        </a>
                                    </li>

                                    <li>
                                        <a href="#!">
                                            <span class="circle">5</span>
                                            <span class="label">Documentación completa</span>
                                        </a>
                                    </li>

                                </ul>
                                <!-- /.Stepers Wrapper -->

                            </div>
                        </div>
                        <div class="row" id="rowPaso3" runat="server" visible="false">
                            <div class="col">
                                <!-- Stepers Wrapper -->
                                <ul class="stepper stepper-horizontal">

                                    <!-- First Step -->
                                    <li>
                                        <a href="#!">
                                            <span class="circle">1</span>
                                            <span class="label">Registrar y confirmar solicitud</span>
                                        </a>
                                    </li>

                                    <!-- Second Step -->
                                    <li>
                                        <a href="#!">
                                            <span class="circle">2</span>
                                            <span class="label">Adjuntar Factura</span>
                                        </a>
                                    </li>

                                    <!-- Third Step -->
                                    <li class="active">
                                        <a href="#!">
                                            <span class="circle">3</span>
                                            <span class="label">Adjuntar Comprobante de Pago</span>
                                        </a>
                                    </li>

                                    <li>
                                        <a href="#!">
                                            <span class="circle">4</span>
                                            <span class="label">REP</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="#!">
                                            <span class="circle">5</span>
                                            <span class="label">Documentación completa</span>
                                        </a>
                                    </li>

                                </ul>
                                <!-- /.Stepers Wrapper -->

                            </div>
                        </div>
                        <div class="row" id="rowPaso4" runat="server" visible="false">
                            <div class="col">
                                <!-- Stepers Wrapper -->
                                <ul class="stepper stepper-horizontal">
                                    <!-- First Step -->
                                    <li>
                                        <a href="#!">
                                            <span class="circle">1</span>
                                            <span class="label">Registrar y confirmar solicitud</span>
                                        </a>
                                    </li>
                                    <!-- Second Step -->
                                    <li>
                                        <a href="#!">
                                            <span class="circle">2</span>
                                            <span class="label">Adjuntar Factura</span>
                                        </a>
                                    </li>
                                    <!-- Third Step -->
                                    <li class="">
                                        <a href="#!">
                                            <span class="circle">3</span>
                                            <span class="label">Adjuntar Comprobante de Pago</span>
                                        </a>
                                    </li>
                                    <li class="active">
                                        <a href="#!">
                                            <span class="circle">4</span>
                                            <span class="label">Adjuntar Recibo de Pago (REP)</span>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="#!">
                                            <span class="circle">5</span>
                                            <span class="label">Documentación completa</span>
                                        </a>
                                    </li>

                                </ul>
                                <!-- /.Stepers Wrapper -->

                            </div>
                        </div>
                        <div class="row" id="rowPaso5" runat="server" visible="false">
                            <div class="col">
                                <!-- Stepers Wrapper -->
                                <ul class="stepper stepper-horizontal">

                                    <!-- First Step -->
                                    <li>
                                        <a href="#!">
                                            <span class="circle">1</span>
                                            <span class="label">Registrar y confirmar solicitud</span>
                                        </a>
                                    </li>

                                    <!-- Second Step -->
                                    <li>
                                        <a href="#!">
                                            <span class="circle">2</span>
                                            <span class="label">Adjuntar Factura</span>
                                        </a>
                                    </li>

                                    <!-- Third Step -->
                                    <li class="">
                                        <a href="#!">
                                            <span class="circle">3</span>
                                            <span class="label">Adjuntar Comprobante de Pago</span>
                                        </a>
                                    </li>

                                    <li>
                                        <a href="#!">
                                            <span class="circle">4</span>
                                            <span class="label">Adjuntar Recibo de Pago (REP)</span>
                                        </a>
                                    </li>

                                    <li class="active">
                                        <a href="#!">
                                            <span class="circle">5</span>
                                            <span class="label">Documentación completa</span>
                                        </a>
                                    </li>

                                </ul>
                                <!-- /.Stepers Wrapper -->

                            </div>
                        </div>
                        <!-- /.Horizontal Steppers -->
                    </div>
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col-md-2">
                                Dependencia
                            </div>
                            <div class="col-md-10">
                                <asp:DropDownList ID="ddlDependencia2" runat="server" Width="100%">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:UpdatePanel ID="UpdatePanel17" runat="server">
                                    <ContentTemplate>
                                        <ajaxToolkit:TabContainer ID="tabFacturas" runat="server" ActiveTabIndex="2" Width="100%" Height="614px" CssClass="ajax__tab_xp" ScrollBars="Vertical">
                                            <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
                                                <HeaderTemplate><i class="fa fa fa-file fa-2x font-weight-bold" aria-hidden="true"></i>&nbsp;Datos Fiscales</HeaderTemplate>
                                                <ContentTemplate>
                                                    <asp:Panel ID="pnl1" runat="server">
                                                        <div class="container-fluid">
                                                            <h6 class="text-dorado font-weight-bold">
                                                                <i class="fa fa-user" aria-hidden="true"></i>
                                                                Datos del Receptor
                                                            </h6>
                                                            <hr />
                                                            <div class="row" id="rowPnl1" runat="server">
                                                                <div class="col alert alert-danger">
                                                                    <h6>NOTA: Contenido únicamente de CONSULTA</h6>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-md-1">RFC </div>
                                                                <div class="col-md-2">
                                                                    <div class="input-group mb-3">
                                                                        <asp:TextBox ID="txtReceptor_Rfc" runat="server" CssClass="form-control" MaxLength="13"></asp:TextBox>
                                                                        <span class="input-group-text primary text-white" id="basic-addon2">
                                                                            <asp:LinkButton ID="linkBttnRFC" runat="server" OnClick="linkBttnRFC_Click"><i class="fa fa-search text-white" aria-hidden="true"></i></asp:LinkButton>
                                                                        </span>
                                                                    </div>


                                                                </div>
                                                                <div class="col-md-1">Persona </div>
                                                                <div class="col-md-2">
                                                                    <asp:UpdatePanel ID="UpdatePanel51" runat="server">
                                                                        <ContentTemplate>
                                                                            <%--<asp:RadioButtonList ID="rdoBttnReceptorTipoPersona" runat="server" OnSelectedIndexChanged="rdoBttnReceptorTipoPersona_SelectedIndexChanged" RepeatDirection="Horizontal" TabIndex="3" AppendDataBoundItems="True" AutoPostBack="True">
                                                                                <asp:ListItem Value="F">Fisica&#160;&#160;</asp:ListItem>
                                                                                <asp:ListItem Value="M">Moral</asp:ListItem>
                                                                            </asp:RadioButtonList>--%>
                                                                            <asp:DropDownList ID="ddlTipoPers" runat="server" AutoPostBack="True" CssClass="form-control" OnSelectedIndexChanged="ddlTipoPers_SelectedIndexChanged">
                                                                                <asp:ListItem Value="0">--SELECCIONAR--</asp:ListItem>
                                                                                <asp:ListItem Value="F">FISICA</asp:ListItem>
                                                                                <asp:ListItem Value="M">MORAL</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                    <asp:RequiredFieldValidator ID="valTipoPers" runat="server" ControlToValidate="ddlTipoPers" ErrorMessage="*Tipo Persona" ValidationGroup="DatosFiscales" InitialValue="0">*Requerido</asp:RequiredFieldValidator>
                                                                </div>
                                                                <div class="col-md-1">
                                                                    <asp:CustomValidator ID="valLongitudRFC0" runat="server" ClientValidationFunction="ValidateTipoPersona" ControlToValidate="ddlTipoPers" ErrorMessage="*Para personas Fisicas el RFC debe ser de 13 caracteres, para MORALES de 12 caracteres." ValidationGroup="DatosFiscales">*Longitud de RFC incorrecto</asp:CustomValidator>
                                                                </div>
                                                                <div class="col-md-1">Razón Social </div>
                                                                <div class="col-md-4">
                                                                    <asp:TextBox ID="txtReceptor_Nombre" runat="server" TabIndex="3" CssClass="form-control"></asp:TextBox><asp:RequiredFieldValidator ID="valRazon_Social" runat="server" ControlToValidate="txtReceptor_Nombre" ErrorMessage="*Razón Social" ForeColor="Red" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                                                </div>

                                                            </div>

                                                            <div class="row">
                                                                <div class="col-md-1">Pais</div>
                                                                <div class="col-md-3">
                                                                    <asp:UpdatePanel ID="UpdatePanel21" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:DropDownList ID="ddlReceptor_Pais" runat="server" CssClass="form-control" Enabled="false"></asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="reqPais" runat="server" ControlToValidate="ddlReceptor_Pais" ErrorMessage="*Pais" InitialValue="0" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </div>
                                                                <div class="col-md-1">Estado </div>
                                                                <div class="col-md-3">
                                                                    <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:DropDownList ID="ddlReceptor_Estado" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEstado_Fiscal_SelectedIndexChanged" TabIndex="2" CssClass="form-control"></asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="ddlReceptor_Estado" ErrorMessage="*Estado" InitialValue="0" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </div>
                                                                <div class="col-md-1">Municipio </div>
                                                                <div class="col-md-3">
                                                                    <asp:DropDownList ID="ddlReceptor_Municipio" runat="server" TabIndex="3" CssClass="form-control"></asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="ddlReceptor_Municipio" ErrorMessage="*Municipio" InitialValue="0" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-md-1">CP </div>
                                                                <div class="col-md-1">
                                                                    <asp:TextBox ID="txtReceptor_CP" runat="server" MaxLength="500" TabIndex="3" CssClass="form-control"></asp:TextBox><asp:RequiredFieldValidator ID="valCP_Fiscal" runat="server" ControlToValidate="txtReceptor_CP" ErrorMessage="*Código Postal" ForeColor="Red" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                                                </div>
                                                                <div class="col-md-1">Calle </div>
                                                                <div class="col-md-4">
                                                                    <asp:TextBox ID="txtReceptor_Domicilio" runat="server" MaxLength="500" TabIndex="4" CssClass="form-control"></asp:TextBox><asp:RequiredFieldValidator ID="valCalle_Fiscal" runat="server" ControlToValidate="txtReceptor_Domicilio" ErrorMessage="*Calle" ForeColor="Red" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                                                </div>
                                                                <div class="col-md-1">Colonia </div>
                                                                <div class="col-md-4">
                                                                    <asp:TextBox ID="txtReceptor_Colonia" runat="server" TabIndex="5" CssClass="form-control"></asp:TextBox><asp:RequiredFieldValidator ID="valColonia_Fiscal" runat="server" ControlToValidate="txtReceptor_Colonia" ErrorMessage="*Colonia" ForeColor="Red" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-md-1">
                                                                    Núm Ext
                                                                </div>
                                                                <div class="col-md-1">
                                                                    <asp:TextBox ID="txtReceptor_NumExt" runat="server" TabIndex="6" CssClass="form-control"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="reqNumExt" runat="server" ControlToValidate="txtReceptor_NumExt" ErrorMessage="*Num Exterior" ForeColor="Red" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                                                </div>
                                                                <div class="col-md-1">Núm Int</div>
                                                                <div class="col-md-1">
                                                                    <asp:TextBox ID="txtReceptor_NumInt" runat="server" TabIndex="7" CssClass="form-control"></asp:TextBox>
                                                                </div>

                                                                <div class="col-md-1">Teléfono</div>
                                                                <div class="col-md-3">
                                                                    <asp:TextBox ID="txtReceptor_Telefono" runat="server" TabIndex="8" CssClass="form-control"></asp:TextBox>
                                                                </div>
                                                                <div class="col-md-1">Correo </div>
                                                                <div class="col-md-3">
                                                                    <asp:TextBox ID="txtReceptor_Correo" runat="server" TabIndex="9" CssClass="form-control"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <h6 class="text-dorado font-weight-bold">
                                                                <i class="fa fa-info-circle" aria-hidden="true"></i>
                                                                Datos de la Factura
                                                            </h6>
                                                            <hr />
                                                            <div class="row">
                                                                <div class="col-md-2">Metodo de Pago </div>
                                                                <div class="col-md-4">
                                                                    <asp:UpdatePanel ID="updPnlReceptor_MetodoPago" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:DropDownList ID="ddlReceptor_MetodoPago" runat="server" TabIndex="11" CssClass="form-control">
                                                                                <asp:ListItem Value="0">--Seleccionar--</asp:ListItem>
                                                                                <asp:ListItem Value="PUE">[PUE] Pago en una sola exhibicion</asp:ListItem>
                                                                                <asp:ListItem Value="PPD">[PPD] Pago en parcialidades o diferido</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                    <asp:RequiredFieldValidator ID="valMetodoPago" runat="server" ControlToValidate="ddlReceptor_MetodoPago" ErrorMessage="*Método de Pago (Pestania 1)" ForeColor="Red" InitialValue="0" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                                                </div>
                                                                <div class="col-md-2">Forma de Pago </div>
                                                                <div class="col-md-4">
                                                                    <asp:DropDownList ID="ddlForma_Pago" runat="server" TabIndex="12" CssClass="form-control">
                                                                        <asp:ListItem Value="0">--Seleccionar--</asp:ListItem>
                                                                        <asp:ListItem Value="01">[01] Efectivo</asp:ListItem>
                                                                        <asp:ListItem Value="02">[02] Cheque Nominativo</asp:ListItem>
                                                                        <asp:ListItem Value="03">[03] Transferencia Electrónica de Fondos</asp:ListItem>
                                                                        <asp:ListItem Value="04">[04] Tarjeta de Crédito</asp:ListItem>
                                                                        <asp:ListItem Value="12">[12] Dacion de Pago</asp:ListItem>
                                                                        <asp:ListItem Value="28">[28] Tarjeta de Débito</asp:ListItem>
                                                                        <asp:ListItem Value="29">[29] Tarjeta de Servicio</asp:ListItem>
                                                                        <asp:ListItem Value="99">[99] Por Definir</asp:ListItem>
                                                                    </asp:DropDownList><asp:RequiredFieldValidator ID="valFP" runat="server" ControlToValidate="ddlForma_Pago" ErrorMessage="*Forma de Pago" ForeColor="Red" InitialValue="0" ValidationGroup="DatosFiscales" Text="*Requerido"></asp:RequiredFieldValidator>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-md-2">Régimen Fiscal</div>
                                                                <div class="col-md-4">
                                                                    <asp:UpdatePanel ID="updPnlCodigoFiscal" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:DropDownList ID="ddlCodigoFiscal" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlCodigoFiscal_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                    <asp:RequiredFieldValidator ID="reqCodigo" runat="server" ControlToValidate="ddlCodigoFiscal" ErrorMessage="*Régimen Fiscal" ForeColor="Red" InitialValue="0" ValidationGroup="DatosFiscales" Text="*Requerido"></asp:RequiredFieldValidator>
                                                                </div>
                                                                <div class="col-md-2">Uso de CFDI </div>
                                                                <div class="col-md-4">
                                                                    <asp:UpdatePanel ID="updPnlCFDI" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:DropDownList ID="ddlCFDI" runat="server" TabIndex="13" CssClass="form-control">
                                                                                <asp:ListItem Value="0">--Seleccionar--</asp:ListItem>
                                                                                <asp:ListItem Value="G01">ADQUISICION DE MERCANCIAS</asp:ListItem>
                                                                                <asp:ListItem Value="G02">DEVOLUCIONES, DESCUENTOS O BONIFICACIONES</asp:ListItem>
                                                                                <asp:ListItem Value="G03">GASTOS EN GENERAL</asp:ListItem>
                                                                                <asp:ListItem Value="I01">CONSTRUCCIONES</asp:ListItem>
                                                                                <asp:ListItem Value="I02">MOBILIARIO Y EQUIPO DE OFICINA POR INVERSIONES</asp:ListItem>
                                                                                <asp:ListItem Value="I03">EQUIPO DE TRANSPORTE</asp:ListItem>
                                                                                <asp:ListItem Value="I04">EQUIPO DE COMPUTO Y ACCESORIOS</asp:ListItem>
                                                                                <asp:ListItem Value="I05">DADOS, TROQUELES, MOLDES, MATRICES Y HERRAMENTAL</asp:ListItem>
                                                                                <asp:ListItem Value="I06">COMUNICACIONES TELEFONICAS</asp:ListItem>
                                                                                <asp:ListItem Value="I07">COMUNICACIONES SATELITALES</asp:ListItem>
                                                                                <asp:ListItem Value="I08">OTRA MAQUINARIA Y EQUIPO</asp:ListItem>
                                                                                <asp:ListItem Value="D01">HONORARIOS MEDICOS, DENTALES Y GASTOS HOSPITALARIOS</asp:ListItem>
                                                                                <asp:ListItem Value="D02">GASTOS MEDICOS POR INCAPACIDAD O DISCAPACIDAD</asp:ListItem>
                                                                                <asp:ListItem Value="D03">GASTOS FUNERALES</asp:ListItem>
                                                                                <asp:ListItem Value="D04">DONATIVOS</asp:ListItem>
                                                                                <asp:ListItem Value="D05">INTERESES REALES EFECTIVAMENTE PAGADAS POR CREDITOS HIPOTECARIOS (CASA HABITACION)</asp:ListItem>
                                                                                <asp:ListItem Value="D06">APORTACIONES VOLUNTARIAS AL SAR</asp:ListItem>
                                                                                <asp:ListItem Value="D07">PRIMAS POR SEGUROS DE GASTOS MEDICOS</asp:ListItem>
                                                                                <asp:ListItem Value="D08">GASTOS DE TRANSPORTACION ESCOLAR OBLIGATORIA</asp:ListItem>
                                                                                <asp:ListItem Value="D09">DEPOSITOS EN C</asp:ListItem>
                                                                                <asp:ListItem Value="D10">PAGOS POR SERVICIOS EDUCATIVOS (COLEGIATURAS)</asp:ListItem>
                                                                                <asp:ListItem Value="P01">POR DEFINIR</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                    <asp:RequiredFieldValidator ID="valCFDI" runat="server" ControlToValidate="ddlCFDI" ErrorMessage="*Uso de CFDI" ForeColor="Red" InitialValue="0" ValidationGroup="DatosFiscales" Text="*Requerido"></asp:RequiredFieldValidator>
                                                                </div>
                                                            </div>

                                                            <br />
                                                            <div class="row">
                                                                <div class="col">
                                                                    <asp:UpdatePanel ID="UpdatePanel18" runat="server">
                                                                        <ContentTemplate>
                                                                            <div>
                                                                                <div class="row">
                                                                                    <div class="col-md-2">Constancia de Situación Fiscal</div>
                                                                                    <div class="col-md-8 mb-3">
                                                                                        <div class="input-group mb-3">
                                                                                            <div class="custom-file input-group-text" style="background-color: #ffffff">
                                                                                                <asp:FileUpload ID="fileConstancia" runat="server" Height="40px" Width="100%" />
                                                                                            </div>
                                                                                            <div class="input-group-prepend">
                                                                                                <asp:LinkButton ID="linkBttnConstancia" runat="server" ValidationGroup="guardar" OnClick="linkBttnConstancia_Click" CssClass="input-group-text text-white"><i class="fa fa-arrow-circle-up" aria-hidden="true"></i>Adjuntar</asp:LinkButton>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="col-md-2">
                                                                                        <%--<asp:RequiredFieldValidator ID="reqConstancia" runat="server" ErrorMessage="*Archivo Constancia" ControlToValidate="fileConstancia" Text="* Requerido" ValidationGroup="DatosFiscales"></asp:RequiredFieldValidator>--%>
                                                                                        <%--<asp:CustomValidator ID="reqConstancia" runat="server" ErrorMessage="CustomValidator" ControlToValidate="linkBttnConstancia" ClientValidationFunction="ValidaConstancia"></asp:CustomValidator>--%>
                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="fileConstancia" ErrorMessage="Archivo incorrecto, debe ser un PDF" ValidationExpression="(.*?)\.(pdf|PDF)$" ValidationGroup="CFDI"></asp:RegularExpressionValidator>
                                                                                    </div>
                                                                                </div>
                                                                                <div class="row">
                                                                                    <div class="col-md-2"></div>
                                                                                    <div class="col-md-9">
                                                                                        <asp:HyperLink ID="linkConstancia" runat="server" CssClass="form-control alert-secondary" Target="_blank">[lblArchivoConstancia]</asp:HyperLink>
                                                                                    </div>
                                                                                    <div class="col-md-1">
                                                                                        <asp:UpdatePanel ID="UpdatePanel19" runat="server">
                                                                                            <ContentTemplate>
                                                                                                <asp:LinkButton ID="linkBttnEliminarConstancia" runat="server" CssClass="btn btn-danger" CausesValidation="False" CommandName="Click" OnClick="linkBttnEliminarConstancia_Click" OnClientClick="return confirm('¿Desea eliminar el registro?');"><i class="fa fa-trash" aria-hidden="true"></i></asp:LinkButton>
                                                                                            </ContentTemplate>
                                                                                        </asp:UpdatePanel>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </ContentTemplate>
                                                                        <Triggers>
                                                                            <asp:PostBackTrigger ControlID="linkBttnConstancia" />
                                                                        </Triggers>
                                                                    </asp:UpdatePanel>
                                                                </div>
                                                            </div>
                                                            <div class="row" id="rowInfAdicional" runat="server">
                                                                <div class="col-md-2">Inf del Pago </div>
                                                                <div class="col-md-10">
                                                                    <div class="alert alert-warning">
                                                                        <div class="row">
                                                                            <div class="col-md-2 font-weight-bold">Total </div>
                                                                            <div class="col-md-10">
                                                                                <asp:Label ID="lblImporte" runat="server"></asp:Label>
                                                                            </div>
                                                                        </div>
                                                                        <div class="row">
                                                                            <div class="col-md-2 font-weight-bold">Conceptos </div>
                                                                            <div class="col-md-10">
                                                                                <asp:Label ID="lblConceptosFac" runat="server"></asp:Label>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-md-2">Descripción </div>
                                                                <div class="col-md-10">
                                                                    <asp:TextBox ID="txtDescConcepto" runat="server" CssClass="form-control" MaxLength="500" TabIndex="16" TextMode="MultiLine" PlaceHolder="Detalle del concepto que se requiera en la factura"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="reqDescConcepto" runat="server" ControlToValidate="txtDescConcepto" ErrorMessage="*Detallar el concepto que se requiera en la factura (Pestania 1)" ForeColor="Red" ValidationGroup="DatosFiscales" Text="*Requerido"></asp:RequiredFieldValidator>
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col">
                                                                    <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:CheckBox ID="chkRechazado" runat="server" AutoPostBack="True" Font-Bold="True" Font-Size="14px" OnCheckedChanged="chkRechazado_CheckedChanged" Text="Rechazado" Visible="False" />
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </div>
                                                            </div>
                                                            <div class="row" id="rowObservaciones" runat="server">
                                                                <div class="col-md-2 font-weight-bold">
                                                                    Motivo del Rechazo 
                                                                </div>
                                                                <div class="col-md-10">
                                                                    <asp:TextBox ID="txtObservaciones" runat="server" Height="67px" TabIndex="17" TextMode="MultiLine" Width="100%"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="reqObservaciones" runat="server" ControlToValidate="txtObservaciones" ErrorMessage="*Motivo del Rechazo" ForeColor="Red" Text="*Requerido" ValidationGroup="DatosFiscalesCaja"></asp:RequiredFieldValidator>
                                                                </div>
                                                            </div>


                                                        </div>
                                                    </asp:Panel>
                                                </ContentTemplate>
                                            </ajaxToolkit:TabPanel>
                                            <ajaxToolkit:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3" Width="100%">
                                                <HeaderTemplate><i class="fa fa-cog fa-2x" aria-hidden="true"></i>&nbsp;Detalle</HeaderTemplate>
                                                <ContentTemplate>
                                                    <asp:UpdatePanel ID="UpdatePanel147" runat="server">
                                                        <ContentTemplate>
                                                            <asp:Panel ID="pnl2" runat="server">
                                                                <div class="container-fluid" id="rowPnl2" runat="server">
                                                                    <div class="row">
                                                                        <div class="col alert alert-danger">
                                                                            <h6>NOTA: Contenido únicamente de CONSULTA</h6>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="container-fluid">
                                                                    <div class="tab-pane" id="profile" role="tabpanel" aria-labelledby="home-profile">
                                                                        <div id="accordion" role="tablist" aria-multiselectable="false">
                                                                            <div class="card" id="collapse2" runat="server">
                                                                                <div class="card-header" role="tab" id="headingTwo">
                                                                                    <div class="mb-0">
                                                                                        <a data-toggle="collapse" data-parent="#accordion" href="#collapseDos" aria-expanded="false" aria-controls="collapseDos" class="collapsed">
                                                                                            <i class="fa fa-file-text-o" aria-hidden="true"></i>
                                                                                            <h3>1. Datos del Oficio</h3>
                                                                                        </a><i class="fa fa-angle-right" aria-hidden="true"></i>
                                                                                    </div>
                                                                                </div>
                                                                                <div id="collapseDos" class="collapse" role="tabpanel" aria-labelledby="headingTwo" aria-expanded="false">
                                                                                    <div class="card-block">
                                                                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                                            <ContentTemplate>
                                                                                                <div class="container-fluid">
                                                                                                    <div class="row">
                                                                                                        <div class="col-md-2">Núm. de Oficio </div>
                                                                                                        <div class="col-md-3">
                                                                                                            <asp:TextBox ID="txtNumOficio" runat="server" TabIndex="24" CssClass="form-control"></asp:TextBox>
                                                                                                        </div>
                                                                                                        <div class="col-md-1">
                                                                                                            <asp:RequiredFieldValidator ID="valNumOficio" runat="server" ControlToValidate="txtNumOficio" ErrorMessage="*Número de Oficio (Pestania 2-&gt;Datos del Oficio)" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                                                                                        </div>
                                                                                                        <div class="col-md-2">Fecha Oficio </div>
                                                                                                        <div class="col-md-4">
                                                                                                            <asp:TextBox ID="txtFechaOficio" runat="server" TabIndex="25" CssClass="form-control"></asp:TextBox><ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="ImageButton2" TargetControlID="txtFechaOficio" />
                                                                                                            <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" /><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFechaOficio" ErrorMessage="*Fecha Oficio(Pestania 2)" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                                <div class="container-fluid">
                                                                                                    <div class="row alert alert-warning">
                                                                                                        <div class="col" style="font-size: 15px">Anexar Oficio</strong></div>
                                                                                                    </div>
                                                                                                    <div class="row">
                                                                                                        <div class="col">
                                                                                                            <div class="col font-weight-bold">
                                                                                                                *Solo formatos PNG, JPG y PDF 
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="fileOficio" ErrorMessage="Archivo incorrecto, debe ser un PNG, JPG ó PDF" ValidationExpression="(.*?)\.(png|PNG|jpg|JPG|jpeg|JPEG|gif|GIF|pdf|PDF)$" ValidationGroup="guardar"></asp:RegularExpressionValidator>
                                                                                                            </div>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                    <div class="row">
                                                                                                        <div class="col-md-8 mb-3">
                                                                                                            <div class="input-group mb-3">
                                                                                                                <div class="custom-file input-group-text" style="background-color: #ffffff">
                                                                                                                    <asp:FileUpload ID="fileOficio" runat="server" Height="30px" />
                                                                                                                </div>
                                                                                                                <div class="input-group-prepend">
                                                                                                                    <asp:LinkButton ID="linkBttnAdjOficio" runat="server" OnClick="linkBttnAdjOficio_Click" CssClass="input-group-text"><i class="fa fa-arrow-circle-up" aria-hidden="true"></i>Adjuntar</asp:LinkButton>
                                                                                                                </div>
                                                                                                            </div>
                                                                                                        </div>
                                                                                                        <div class="col-md-4">
                                                                                                            <asp:RegularExpressionValidator ID="reqOficio" runat="server" ControlToValidate="fileOficio" ErrorMessage="Archivo incorrecto, debe ser un PDF" ValidationExpression="(.*?)\.(pdf|PDF)$"></asp:RegularExpressionValidator>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                    <div class="row">
                                                                                                        <div class="col-md-11">
                                                                                                            <asp:HyperLink ID="lblArchivoOficio" runat="server" Target="_blank" CssClass="form-control">[lblArchivoVoucher]</asp:HyperLink>
                                                                                                        </div>
                                                                                                        <div class="col-md-1">
                                                                                                            <asp:LinkButton ID="linkBttnEliminarOficio" runat="server" CausesValidation="False" CommandName="Click" CssClass="btn btn-danger" OnClick="linkBttnEliminarOficio_Click" OnClientClick="return confirm('¿Desea eliminar el registro?');"><i class="fa fa-trash" aria-hidden="true"></i></asp:LinkButton>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </ContentTemplate>
                                                                                            <Triggers>
                                                                                                <asp:PostBackTrigger ControlID="linkBttnAdjOficio" />
                                                                                            </Triggers>
                                                                                        </asp:UpdatePanel>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                            <div class="card" id="collapse3" runat="server">
                                                                                <div class="card-header" role="tab" id="headingTres">
                                                                                    <div class="mb-0">
                                                                                        <a data-toggle="collapse" data-parent="#accordion" href="#collapseTres" aria-expanded="false" aria-controls="collapseTres" class="collapsed"><i class="fa fa-file-text-o" aria-hidden="true"></i>
                                                                                            <h3>1. Importe/Convenio</h3>
                                                                                        </a><i class="fa fa-angle-right" aria-hidden="true"></i>
                                                                                    </div>
                                                                                </div>
                                                                                <div id="collapseTres" class="collapse" role="tabpanel" aria-labelledby="headingTres" aria-expanded="false">
                                                                                    <div class="card-block">
                                                                                        <asp:UpdatePanel ID="updPnlConvenio" runat="server">
                                                                                            <ContentTemplate>
                                                                                                <div class="container-fluid">
                                                                                                    <div class="row">
                                                                                                        <div class="col-md-1">Importe </div>
                                                                                                        <div class="col-md-2">
                                                                                                            <asp:TextBox ID="txtImporteConvenio" runat="server" TabIndex="27" Width="100px" CssClass="form-control"></asp:TextBox><asp:RequiredFieldValidator ID="valImpConvenio" runat="server" ControlToValidate="txtImporteConvenio" ErrorMessage="*Importe (Pestania 2-&gt;Convenio)" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                                                                                        </div>
                                                                                                        <div class="col-md-2">IVA </div>
                                                                                                        <div class="col-md-2">
                                                                                                            <asp:TextBox ID="txtIVAConvenio" runat="server" AutoPostBack="True" TabIndex="28" OnTextChanged="txtIVA_TextChanged" Width="100px" CssClass="form-control"></asp:TextBox>
                                                                                                        </div>
                                                                                                        <div class="col-md-1">
                                                                                                            <asp:RequiredFieldValidator ID="valIva" runat="server" ControlToValidate="txtIVAConvenio" ErrorMessage="*Iva(Pestania 2-&gt;Convenio)" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                                                                                        </div>
                                                                                                        <div class="col-md-1">Total </div>
                                                                                                        <div class="col-md-2">
                                                                                                            <asp:TextBox ID="txtTotalConvenio" runat="server" Width="100px" TabIndex="29" CssClass="form-control"></asp:TextBox>
                                                                                                        </div>
                                                                                                        <div class="col-md-1">
                                                                                                            <asp:RequiredFieldValidator ID="valTotal" runat="server" ControlToValidate="txtTotalConvenio" ErrorMessage="*Total(Pestania 2-&gt;Convenio)" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                    <div class="row">
                                                                                                        <div class="col-md-1">Observaciones </div>
                                                                                                        <div class="col-md-11">
                                                                                                            <asp:TextBox ID="txtObservacionesConvenio" runat="server" Height="100px" TabIndex="30" PlaceHolder="Especificar concepto de la factura, el importe total, en caso de que aplique desglosar IVA." TextMode="MultiLine" Width="90%"></asp:TextBox>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                    <div class="row">
                                                                                                        <div class="col">
                                                                                                            <div class="note note-warning" style="font-size: 14px">
                                                                                                                <div class="row">
                                                                                                                    <div class="col">Anexar Convenio </div>
                                                                                                                </div>
                                                                                                                <div class="row">
                                                                                                                    <div class="col font-weight-bold">
                                                                                                                        *Solo formatos PNG, JPG y PDF
                                                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="fileConvenio" ErrorMessage="Archivo incorrecto, debe ser un PNG, JPG ó PDF" ValidationExpression="(.*?)\.(png|PNG|jpg|JPG|jpeg|JPEG|gif|GIF|pdf|PDF)$" ValidationGroup="guardar"></asp:RegularExpressionValidator>
                                                                                                                    </div>
                                                                                                                </div>
                                                                                                                <div class="row">
                                                                                                                    <div class="col-md-10">
                                                                                                                        <asp:FileUpload ID="fileConvenio" runat="server" Height="30px" />
                                                                                                                    </div>
                                                                                                                    <div class="col-md-2">
                                                                                                                        <asp:Button ID="btnConvenio" runat="server" TabIndex="31" CssClass="btn btn-blue-grey" Font-Size="Smaller" OnClick="btnConvenio_Click" Text="ADJUNTAR" ValidationGroup="guardar" />
                                                                                                                    </div>
                                                                                                                </div>
                                                                                                                <div class="row">
                                                                                                                    <div class="col-md-11">
                                                                                                                        <asp:HyperLink ID="lblArchivoConvenio" runat="server" Target="_blank" CssClass="form-control">[lblArchivoConvenio]</asp:HyperLink>
                                                                                                                    </div>
                                                                                                                    <div class="col-md-1">
                                                                                                                        <asp:LinkButton ID="linkBttnEliminarConvenio" runat="server" CausesValidation="False" CssClass="btn btn-danger" CommandName="Click" OnClick="linkBttnEliminarConvenio_Click" OnClientClick="return confirm('¿Desea eliminar el registro?');"><i class="fa fa-trash aria-hidden=" true"=""></i></asp:LinkButton></td>
                                                                                                                    </div>
                                                                                                                </div>
                                                                                                            </div>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </ContentTemplate>
                                                                                            <Triggers>
                                                                                                <asp:PostBackTrigger ControlID="btnConvenio" />
                                                                                            </Triggers>
                                                                                        </asp:UpdatePanel>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                            <div class="card" id="collapse1" runat="server">
                                                                                <div class="card-header" role="tab" id="headingOne">
                                                                                    <div class="mb-0">
                                                                                        <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne" aria-expanded="false" aria-controls="collapseOne" class="collapsed"><i class="fa fa-file-text-o" aria-hidden="true"></i>
                                                                                            <h3>2. Comprobante de Pago</h3>
                                                                                        </a><i class="fa fa-angle-right" aria-hidden="true"></i>
                                                                                    </div>
                                                                                </div>
                                                                                <div id="collapseOne" class="collapse" role="tabpanel" aria-labelledby="headingOne" aria-expanded="false" style="">
                                                                                    <div class="card-block">
                                                                                        <div class="container-fluid">
                                                                                            <div class="row">
                                                                                                <div class="col-md-1">Folio</div>
                                                                                                <div class="col-md-1">
                                                                                                    <asp:TextBox ID="txtFolio" runat="server" TabIndex="18" Width="100%"></asp:TextBox>
                                                                                                </div>
                                                                                                <div class="col-md-1">
                                                                                                    <asp:RequiredFieldValidator ID="valFolio" runat="server" ControlToValidate="txtFolio" ErrorMessage="*Folio(Datos del Comprobante de Pago - Pestania 2)" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                                                                                </div>
                                                                                                <div class="col-md-1">Fecha Pago</div>
                                                                                                <div class="col-md-2">
                                                                                                    <asp:TextBox ID="txtFecha" runat="server" Width="100%" TabIndex="19"></asp:TextBox>
                                                                                                </div>
                                                                                                <div class="col-md-1">
                                                                                                    <ajaxToolkit:CalendarExtender ID="txtFecha_CalendarExtender" runat="server" PopupButtonID="imgFecha" TargetControlID="txtFecha" />
                                                                                                    <asp:ImageButton ID="imgFecha" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                                                                                                </div>
                                                                                                <div class="col-md-1">
                                                                                                    <asp:RequiredFieldValidator ID="valFecha" runat="server" ControlToValidate="txtFecha" ErrorMessage="*Fecha(Datos del Comprobante de Pago - Pestania 2)" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                                                                                </div>
                                                                                                <div class="col-md-1">Subtotal</div>
                                                                                                <div class="col-md-1">
                                                                                                    <asp:TextBox ID="txtImporteDeposito" runat="server" TabIndex="20" Width="100%"></asp:TextBox>
                                                                                                </div>
                                                                                                <div class="col-md-1">
                                                                                                    <asp:RequiredFieldValidator ID="valImporte" runat="server" ControlToValidate="txtImporteDeposito" ErrorMessage="*Importe(Datos del Comprobante de Pago - Pestania 2)" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                                                                                </div>
                                                                                                <div class="col-md-1">
                                                                                                    <asp:UpdatePanel ID="UpdatePanel15" runat="server">
                                                                                                        <ContentTemplate>
                                                                                                            <asp:CheckBox ID="chkIvaDes" runat="server" AutoPostBack="True" OnCheckedChanged="chkIvaDes_CheckedChanged" TabIndex="21" Text="¿Con IVA desglozado?" />
                                                                                                        </ContentTemplate>
                                                                                                    </asp:UpdatePanel>
                                                                                                </div>
                                                                                            </div>
                                                                                            <asp:UpdatePanel ID="UpdatePanel16" runat="server">
                                                                                                <ContentTemplate>
                                                                                                    <div class="row" id="rowIvaDeposito" runat="server" visible="false">
                                                                                                        <div class="col-md-1">IVA</div>
                                                                                                        <div class="col-md-1">
                                                                                                            <asp:TextBox ID="txtIvaDeposito" runat="server" TabIndex="22" Width="100%"></asp:TextBox>
                                                                                                        </div>
                                                                                                        <div class="col-md-1">
                                                                                                            <asp:RequiredFieldValidator ID="reqIvaDes" runat="server" ControlToValidate="txtIvaDeposito" ErrorMessage="*Iva (Datos del Comprobante de Pago - Pestania 2)" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                                                                                        </div>
                                                                                                        <div class="col-md-1">Total</div>
                                                                                                        <div class="col-md-1">
                                                                                                            <asp:TextBox ID="txtTotalDeposito" runat="server" TabIndex="23" Width="100%"></asp:TextBox>
                                                                                                        </div>
                                                                                                        <div class="col-md-1">
                                                                                                            <asp:RequiredFieldValidator ID="reqTotDes" runat="server" ControlToValidate="txtTotalDeposito" ErrorMessage="*Total (Datos del Comprobante de Pago - Pestania 2)" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </ContentTemplate>
                                                                                            </asp:UpdatePanel>
                                                                                            <div class="row" runat="server" id="rowFA">
                                                                                                <div class="col-md-2">Folio de Factura Pagada</div>
                                                                                                <div class="col-md-3">
                                                                                                    <asp:TextBox ID="txtFolioFactPagada" runat="server"></asp:TextBox>
                                                                                                    <asp:RequiredFieldValidator ID="reqFolioFactPagada" runat="server" ControlToValidate="txtFolioFactPagada" ErrorMessage="*Folio de Factura Pagada (Datos del Comprobante de Pago - Pestania 2)" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                                                                                </div>
                                                                                                <div class="col-md-2">Método de Pago</div>
                                                                                                <div class="col-md-3">
                                                                                                    <asp:DropDownList ID="ddlReceptor_MetodoPagoFA" runat="server">
                                                                                                        <asp:ListItem Value="0">--Seleccionar--</asp:ListItem>
                                                                                                        <asp:ListItem Value="PUE">[PUE] Pago en una sola exhibicion</asp:ListItem>
                                                                                                        <asp:ListItem Value="PPD">[PPD] Pago en parcialidades o diferido</asp:ListItem>
                                                                                                    </asp:DropDownList>
                                                                                                    <asp:RequiredFieldValidator ID="reqMetodoPago" runat="server" ControlToValidate="ddlReceptor_MetodoPagoFA" ErrorMessage="*Método de Pago (Datos del Comprobante de Pago - Pestania 2)" ValidationGroup="DatosFiscales" InitialValue="0">*Requerido</asp:RequiredFieldValidator>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="row">
                                                                                                <div class="col">
                                                                                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                                                        <ContentTemplate>
                                                                                                            <div class="container-fluid">
                                                                                                                <div class="row alert alert-warning">
                                                                                                                    <div class="col" style="font-size: 15px">Anexar Comprobante de Pago <strong>(agregar documento legible y a color)</strong></div>
                                                                                                                </div>
                                                                                                                <div class="row">
                                                                                                                    <div class="col-md-8 mb-3">
                                                                                                                        <div class="input-group mb-3">
                                                                                                                            <div class="custom-file input-group-text" style="background-color: #ffffff">
                                                                                                                                <asp:FileUpload ID="fileVoucher" runat="server" Height="40px" Width="100%" />
                                                                                                                            </div>
                                                                                                                            <div class="input-group-prepend">
                                                                                                                                <asp:LinkButton ID="linkBttnAdjVoucher" runat="server" ValidationGroup="guardar" OnClick="linkBttnAdjVoucher_Click" CssClass="input-group-text text-white"><i class="fa fa-arrow-circle-up" aria-hidden="true"></i>Adjuntar</asp:LinkButton>
                                                                                                                            </div>
                                                                                                                        </div>
                                                                                                                    </div>
                                                                                                                    <div class="col-md-4">
                                                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator107" runat="server" ControlToValidate="fileVoucher" ErrorMessage="Archivo incorrecto, debe ser un PDF" ValidationExpression="(.*?)\.(pdf|PDF)$" ValidationGroup="CFDI"></asp:RegularExpressionValidator>
                                                                                                                    </div>
                                                                                                                </div>
                                                                                                                <div class="row">
                                                                                                                    <div class="col-md-11">
                                                                                                                        <asp:HyperLink ID="lblArchivoVoucher" runat="server" Target="_blank" CssClass="form-control">[lblArchivoVoucher]</asp:HyperLink><asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="*El comprobante es requerido (Datos del Voucher - Pestania 2)" OnServerValidate="VoucherAdjunto" ValidationGroup="DatosFiscales">*Comprobante Requerido</asp:CustomValidator>
                                                                                                                    </div>
                                                                                                                    <div class="col-md-1">
                                                                                                                        <asp:UpdatePanel ID="UpdatePanel49" runat="server">
                                                                                                                            <ContentTemplate>
                                                                                                                                <asp:LinkButton ID="linkBttnEliminarVoucher" runat="server" CssClass="btn btn-danger" CausesValidation="False" CommandName="Click" OnClick="linkBttnEliminarVoucher_Click" OnClientClick="return confirm('¿Desea eliminar el registro?');"><i class="fa fa-trash aria-hidden="true"></i></asp:LinkButton>
                                                                                                                            </ContentTemplate>
                                                                                                                        </asp:UpdatePanel>
                                                                                                                    </div>
                                                                                                                </div>
                                                                                                            </div>
                                                                                                        </ContentTemplate>
                                                                                                        <Triggers>
                                                                                                            <asp:PostBackTrigger ControlID="linkBttnAdjVoucher" />
                                                                                                        </Triggers>
                                                                                                    </asp:UpdatePanel>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                            <div class="card" id="collapse4" runat="server">
                                                                                <div class="card-header" role="tab" id="headingCuatro">
                                                                                    <div class="mb-0">
                                                                                        <a data-toggle="collapse" data-parent="#accordion" href="#collapseCuatro" aria-expanded="false" aria-controls="collapseCuatro" class="collapsed"><i class="fa fa-file-text-o" aria-hidden="true"></i>
                                                                                            <h3>3. Recibo Electrónico de Pago (REP)</h3>
                                                                                        </a><i class="fa fa-angle-right" aria-hidden="true"></i>
                                                                                    </div>
                                                                                </div>
                                                                                <div id="collapseCuatro" class="collapse" role="tabpanel" aria-labelledby="headingCuatro" aria-expanded="false">
                                                                                    <div class="card-block">
                                                                                        <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                                                            <ContentTemplate>
                                                                                                <div class="container-fluid">
                                                                                                    <div class="row">
                                                                                                        <div class="col-md-1">Fecha </div>
                                                                                                        <div class="col-md-2">
                                                                                                            <asp:TextBox ID="txtFechaRep" runat="server" TabIndex="32" Width="100px"></asp:TextBox><ajaxToolkit:CalendarExtender ID="calextFechaRep" runat="server" PopupButtonID="imgFechaRep" TargetControlID="txtFechaRep" />
                                                                                                            <asp:ImageButton ID="imgFechaRep" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" /><asp:RequiredFieldValidator ID="reqFechaRep" runat="server" ControlToValidate="txtFechaRep" ErrorMessage="*REP (Pestania 2-&gt;Fecha REP)" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                                                                                        </div>
                                                                                                        <div class="col-md-2">Número </div>
                                                                                                        <div class="col-md-2">
                                                                                                            <asp:TextBox ID="txtNumREP" runat="server" Width="100px" TabIndex="33"></asp:TextBox>
                                                                                                        </div>
                                                                                                        <div class="col-md-1">
                                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNumREP" ErrorMessage="*Iva(Pestania 2-&gt;Número REP)" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                    <div class="row">
                                                                                                        <div class="col">
                                                                                                            <div class="note note-warning" style="font-size: 14px">
                                                                                                                <div class="row">
                                                                                                                    <div class="col">Anexar REP </div>
                                                                                                                </div>
                                                                                                                <div class="row">
                                                                                                                    <div class="col font-weight-bold">
                                                                                                                        *Solo formatos PNG, JPG y PDF
                                                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="fileREP" ErrorMessage="Archivo incorrecto, debe ser un PNG, JPG ó PDF" ValidationExpression="(.*?)\.(png|PNG|jpg|JPG|jpeg|JPEG|gif|GIF|pdf|PDF)$" ValidationGroup="guardar"></asp:RegularExpressionValidator>
                                                                                                                    </div>
                                                                                                                </div>
                                                                                                                <div class="row">
                                                                                                                    <div class="col-md-10">
                                                                                                                        <asp:FileUpload ID="fileREP" runat="server" Height="30px" />
                                                                                                                    </div>
                                                                                                                    <div class="col-md-2">
                                                                                                                        <asp:Button ID="bttnAgregarREP" runat="server" TabIndex="34" CssClass="btn btn-blue-grey" Font-Size="Smaller" OnClientClick="Collapse4" Text="ADJUNTAR" OnClick="bttnAgregarREP_Click" />
                                                                                                                    </div>
                                                                                                                </div>
                                                                                                                <div class="row">
                                                                                                                    <div class="col-md-11">
                                                                                                                        <asp:HyperLink ID="lblArchivoREP" runat="server" Target="_blank" CssClass="form-control">[lblArchivoREP]</asp:HyperLink>
                                                                                                                    </div>
                                                                                                                    <div class="col-md-1">
                                                                                                                        <asp:LinkButton ID="linkBttnEliminarREP" runat="server" CausesValidation="False" CssClass="btn btn-danger" OnClick="linkBttnEliminarREP_Click" OnClientClick="return confirm('¿Desea eliminar el registro?');"><i class="fa fa-trash aria-hidden=" true"=""></i></asp:LinkButton></td>
                                                                                                                    </div>
                                                                                                                </div>
                                                                                                            </div>
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </ContentTemplate>
                                                                                            <Triggers>
                                                                                                <asp:PostBackTrigger ControlID="bttnAgregarREP" />
                                                                                            </Triggers>
                                                                                        </asp:UpdatePanel>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <br />
                                                                <div class="container-fluid">
                                                                    <div class="row">
                                                                        <div class="col">
                                                                            <asp:CustomValidator ID="valConceptos" runat="server" ErrorMessage="*Se debe asignar al menor un concepto (Datos del Voucher - Pestania 2)" OnServerValidate="ConceptosAsignados" ValidationGroup="DatosFiscales">*Conceptos Requeridos</asp:CustomValidator>
                                                                        </div>
                                                                    </div>
                                                                    <div class="row">
                                                                        <div class="col-md-6">
                                                                            <asp:GridView ID="grvConceptosDisp" runat="server" AutoGenerateColumns="False" EmptyDataText="No se encontro ningún registro" OnPageIndexChanging="grvConceptosDisp_PageIndexChanging" OnSelectedIndexChanged="grvConceptosDisp_SelectedIndexChanged" Width="100%" OnRowDataBound="grvConceptosDisp_RowDataBound" CssClass="mGrid">
                                                                                <Columns>
                                                                                    <asp:BoundField DataField="ClaveConcepto" HeaderText="CVE">
                                                                                        <HeaderStyle HorizontalAlign="Left" />
                                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="Descripcion" HeaderText="DESCRIPCIÓN">
                                                                                        <HeaderStyle HorizontalAlign="Left" />
                                                                                        <ItemStyle HorizontalAlign="Left" Width="70%" />
                                                                                    </asp:BoundField>
                                                                                    <asp:CommandField SelectText="Agregar" ShowSelectButton="True" />
                                                                                </Columns>
                                                                                <FooterStyle CssClass="enc" />
                                                                                <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                                                <SelectedRowStyle CssClass="sel" />
                                                                                <HeaderStyle CssClass="enc" />
                                                                                <AlternatingRowStyle CssClass="alt" />
                                                                            </asp:GridView>
                                                                        </div>
                                                                        <div class="col-md-6">
                                                                            <asp:GridView ID="grvConceptos" runat="server" AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="No se encontro ningún registro" OnRowDeleting="grvConceptos_RowDeleting" Width="100%">
                                                                                <Columns>
                                                                                    <asp:BoundField DataField="ClaveConcepto" HeaderText="Cve">
                                                                                        <HeaderStyle HorizontalAlign="Left" />
                                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                                    </asp:BoundField>
                                                                                    <asp:BoundField DataField="Descripcion" HeaderText="Descripción">
                                                                                        <HeaderStyle HorizontalAlign="Left" />
                                                                                        <ItemStyle HorizontalAlign="Left" Width="70%" />
                                                                                    </asp:BoundField>
                                                                                    <asp:CommandField ShowDeleteButton="True" />
                                                                                </Columns>
                                                                                <FooterStyle CssClass="enc" />
                                                                                <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                                                <SelectedRowStyle CssClass="sel" />
                                                                                <HeaderStyle CssClass="enc" />
                                                                                <AlternatingRowStyle CssClass="alt" />
                                                                            </asp:GridView>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </asp:Panel>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </ContentTemplate>
                                            </ajaxToolkit:TabPanel>
                                            <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="Imagen de la Factura">
                                                <HeaderTemplate><i class="fa fa-upload fa-2x" aria-hidden="true"></i>&nbsp;Factura (xml,pdf)</HeaderTemplate>
                                                <ContentTemplate>
                                                    <asp:UpdatePanel ID="UpdatePanelFoto" runat="server">
                                                        <ContentTemplate>
                                                            <div class="container">
                                                                <asp:Panel ID="pnlFacturas" runat="server">
                                                                    <div class="row">
                                                                        <div class="col-md-1">Folio</div>
                                                                        <div class="col-md-2">
                                                                            <asp:TextBox ID="txtFolio_Fact_Cja" runat="server" CssClass="form-control"></asp:TextBox>
                                                                        </div>
                                                                        <div class="col-md-1">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtFolio_Fact_Cja" ErrorMessage="*Requerido" ValidationGroup="CFDI"></asp:RequiredFieldValidator>
                                                                        </div>
                                                                        <div class="col-md-1">Fecha</div>
                                                                        <div class="col-md-2">
                                                                            <div class="input-group mb-3">
                                                                                <asp:TextBox ID="txtFecha_Fact_Cja" runat="server" AutoPostBack="True" CssClass="form-control" onkeyup="javascript:this.value='';"></asp:TextBox><ajaxToolkit:CalendarExtender ID="txtFecha_Fact_Cja_CalendarExtender" runat="server" PopupButtonID="imgFecha_Fact_Cja" TargetControlID="txtFecha_Fact_Cja" />
                                                                                <span class="input-group-text primary text-white" id="basic-addon2">
                                                                                    <asp:ImageButton ID="imgFecha_Fact_Cja" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                                                                                </span>
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-md-2">
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtFecha_Fact_Cja" ErrorMessage="*Requerido" ValidationGroup="CFDI"></asp:RequiredFieldValidator>
                                                                        </div>
                                                                        <div class="col-md-1">Status</div>
                                                                        <div class="col-md-2">
                                                                            <asp:DropDownList ID="ddlStatusFact" runat="server" CssClass="form-control">
                                                                                <asp:ListItem Value="A">Activo</asp:ListItem>
                                                                                <asp:ListItem Value="C">Cancelado</asp:ListItem>
                                                                                <asp:ListItem Value="SC">Solicita Cancelación</asp:ListItem>
                                                                            </asp:DropDownList>
                                                                        </div>
                                                                    </div>

                                                                    <div class="row" id="divFacturas" runat="server">
                                                                        <div class="col-md-5">
                                                                            <asp:UpdatePanel ID="UpdatePanel24" runat="server">
                                                                                <ContentTemplate>
                                                                                    <div class="input-group mb-3">
                                                                                        <div class="input-group-prepend">
                                                                                            <span class="input-group-text text-white">XML</span>
                                                                                        </div>
                                                                                        <div class="custom-file" style="width: 70%">
                                                                                            <asp:FileUpload ID="FileFacturaXML" runat="server" class="form-control" Height="40px" Width="100%" />
                                                                                        </div>
                                                                                        <div class="input-group-append">
                                                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="FileFacturaXML" ErrorMessage="Archivo incorrecto, debe ser un XML" ValidationExpression="(.*?)\.(xml|XML)$" ValidationGroup="CFDI"></asp:RegularExpressionValidator>
                                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*Archivo XML" ControlToValidate="FileFacturaXML" Text="* Requerido" ValidationGroup="CFDI"></asp:RequiredFieldValidator>
                                                                                        </div>
                                                                                    </div>
                                                                                </ContentTemplate>
                                                                                <Triggers>
                                                                                    <asp:PostBackTrigger ControlID="bttnAgregaFactura" />
                                                                                </Triggers>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                        <div class="col-md-5">
                                                                            <asp:UpdatePanel ID="UpdatePanel25" runat="server">
                                                                                <ContentTemplate>
                                                                                    <div class="input-group mb-3">
                                                                                        <div class="input-group-prepend">
                                                                                            <span class="input-group-text text-white">PDF</span>
                                                                                        </div>
                                                                                        <div class="custom-file" style="width: 70%">
                                                                                            <asp:FileUpload ID="FileFacturaPDF" runat="server" class="form-control" Height="40px" Width="100%" />
                                                                                        </div>
                                                                                        <div class="input-group-append">
                                                                                            <asp:RegularExpressionValidator ID="reqExpFacturaPDF" runat="server" ControlToValidate="FileFacturaPDF" ErrorMessage="Archivo incorrecto, debe ser un PDF" ValidationExpression="(.*?)\.(pdf|PDF)$" ValidationGroup="CFDI"></asp:RegularExpressionValidator>
                                                                                            <asp:RequiredFieldValidator ID="reqFacturaPDF" runat="server" ControlToValidate="FileFacturaPDF" ErrorMessage="*Archivo PDF" Text="* Requerido" ValidationGroup="CFDI"></asp:RequiredFieldValidator>
                                                                                        </div>
                                                                                    </div>
                                                                                </ContentTemplate>
                                                                                <Triggers>
                                                                                    <asp:PostBackTrigger ControlID="bttnAgregaFactura" />
                                                                                </Triggers>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                        <div class="col-md-2">
                                                                            <asp:LinkButton ID="bttnAgregaFactura" runat="server" ValidationGroup="CFDI" OnClick="bttnAgregaFactura_Click" CssClass="btn btn-grey"><i class="fa fa-arrow-circle-up" aria-hidden="true"></i> Adjuntar</asp:LinkButton>
                                                                        </div>
                                                                    </div>
                                                                </asp:Panel>
                                                                <div class="row">
                                                                    <div class="col">
                                                                        <asp:GridView ID="grdArchivos" runat="server" AutoGenerateColumns="False" CssClass="mGrid" OnRowDeleting="grdArchivos_RowDeleting" Width="100%">
                                                                            <Columns>
                                                                                <asp:BoundField DataField="Fecha_Fact_Cja" HeaderText="Fecha" />
                                                                                <asp:BoundField DataField="Folio_Fact_Cja" HeaderText="Folio" />
                                                                                <asp:TemplateField>
                                                                                    <HeaderTemplate>
                                                                                        <i class="fa fa-file-code-o fa-2x" aria-hidden="true"></i>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:HyperLink ID="linkXml" runat="server" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "Ruta_Xml") %>' Target="_blank" Font-Bold="True">XML</asp:HyperLink>
                                                                                    </ItemTemplate>
                                                                                    <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField>
                                                                                    <HeaderTemplate>
                                                                                        <i class="fa fa-file-pdf-o fa-2x" aria-hidden="true"></i>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:HyperLink ID="linkPdf" runat="server" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "Ruta_Pdf") %>' Target="_blank" Font-Bold="True">PDF</asp:HyperLink>
                                                                                    </ItemTemplate>
                                                                                    <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField ShowHeader="False">
                                                                                    <HeaderTemplate>
                                                                                        <i class="fa fa-trash fa-2x" aria-hidden="true"></i>
                                                                                    </HeaderTemplate>
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete" Text="Eliminar" Font-Bold="True"></asp:LinkButton>
                                                                                    </ItemTemplate>
                                                                                    <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Status">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblDescStatus" runat="server" Text='<%# Bind("Status_Carga") %>' Font-Bold="True"></asp:Label>
                                                                                    </ItemTemplate>
                                                                                    <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Acción">
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton ID="linkBttnStatusFact" runat="server" CssClass="btn btn-danger" Visible='<%# Bind("HABILITADO") %>' OnClick="linkBttnStatusFact_Click" Text="Aceptar Cancelación"></asp:LinkButton>
                                                                                    </ItemTemplate>
                                                                                    <HeaderStyle HorizontalAlign="Center" Width="12%" />
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField DataField="Status" />
                                                                            </Columns>
                                                                            <FooterStyle CssClass="enc" />
                                                                            <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                                            <SelectedRowStyle CssClass="sel" />
                                                                            <HeaderStyle CssClass="enc" />
                                                                            <AlternatingRowStyle CssClass="alt" />
                                                                        </asp:GridView>
                                                                    </div>

                                                                </div>
                                                                <%--<div class="row">
                                                                    <div class="col">
                                                                        <p>
  <a class="btn btn-danger" data-toggle="collapse" href="#collapseExample" role="button" aria-expanded="false" aria-controls="collapseExample">
    Solicitar Cancelación de Factura
  </a>
  
</p>
<div class="collapse" id="collapseExample">
  <div class="card card-body">
    Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident.
  </div>
</div>
<div id='collapsediv1' class='collapse div1'>
  <div>
    AAAAAAAAAA
  </div>
  <div>
    BBBBBBBBBBB
  </div>
</div>
                                                                    </div>
                                                                </div>--%>
                                                            </div>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </ContentTemplate>
                                            </ajaxToolkit:TabPanel>
                                        </ajaxToolkit:TabContainer>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col text-right">
                                <asp:CheckBox ID="chkValida" runat="server" Checked="True" OnCheckedChanged="chkValida_CheckedChanged" Text="Realizar validación" AutoPostBack="True" Font-Bold="True" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <asp:ValidationSummary ID="validationSumGuardar" runat="server" CssClass="mensaje_rojo" HeaderText="Los siguientes campos son requeridos:" ValidationGroup="DatosFiscales" />
                            </div>

                            <div class="col-md-6 text-right">
                                <asp:LinkButton ID="linkBttnVerRecibo" runat="server" CssClass="btn btn-grey" ValidationGroup="Ninguno" OnClick="linkBttnVerRecibo_Click"><i class="fa fa-file"></i> Ver Recibo</asp:LinkButton>
                                <asp:LinkButton ID="linkBttnCancelarSol" runat="server" CssClass="btn btn-danger" ValidationGroup="DatosFiscales" OnClick="linkBttnCancelarSol_Click"><i class="fa fa-trash" aria-hidden="true"></i> Cancelar Solicitud</asp:LinkButton>
                                <asp:LinkButton ID="linkBttnGuardarEditar" runat="server" CssClass="btn btn-info" ValidationGroup="DatosFiscales" OnClick="linkBttnGuardarEditar_Click"><i class="fa fa-floppy-o" aria-hidden="true"></i> Guardar</asp:LinkButton>
                                <asp:LinkButton ID="linkBttnEnviarSol" runat="server" CssClass="btn btn-primary" ValidationGroup="DatosFiscales" OnClick="linkBttnEnviarSol_Click"><i class="fa fa-paper-plane" aria-hidden="true"></i> Guardar y Enviar Solicitud</asp:LinkButton>
                                <asp:LinkButton ID="linkBttnCancelarEditar" CssClass="btn btn-grey" runat="server" ValidationGroup="Ninguno" OnClick="linkBttnCancelarEditar_Click"><i class="fa fa-window-close" aria-hidden="true"></i> Salir</asp:LinkButton>

                                <%--                                <asp:Button ID="bttnVerRecibo" runat="server" CssClass="btn btn-grey" Text="VER RECIBO" OnClick="bttnVerRecibo_Click" ValidationGroup="Ninguno" />
                                &nbsp;<asp:Button ID="btnGuardarEditar" runat="server" CssClass="btn btn-grey" OnClick="btnGuardarEditar_Click" TabIndex="14" Text="GUARDAR" ValidationGroup="DatosFiscales" />
                                &nbsp;<asp:Button ID="Button1" runat="server" CssClass="btn btn-info" OnClick="btnGuardarEditar_Click" TabIndex="14" Text="ENVIAR SOLICITUD" ValidationGroup="DatosFiscales" />
                                &nbsp;<asp:Button ID="btnCancelarEditar" runat="server" CssClass="btn btn-blue-grey" OnClick="btnCancelarEditar_Click" TabIndex="15" Text="SALIR" ValidationGroup="Ninguno" />--%>
                            </div>
                        </div>
                    </div>
                </asp:View>
            </asp:MultiView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--                                <asp:Button ID="bttnVerRecibo" runat="server" CssClass="btn btn-grey" Text="VER RECIBO" OnClick="bttnVerRecibo_Click" ValidationGroup="Ninguno" />
                                &nbsp;<asp:Button ID="btnGuardarEditar" runat="server" CssClass="btn btn-grey" OnClick="btnGuardarEditar_Click" TabIndex="14" Text="GUARDAR" ValidationGroup="DatosFiscales" />
                                &nbsp;<asp:Button ID="Button1" runat="server" CssClass="btn btn-info" OnClick="btnGuardarEditar_Click" TabIndex="14" Text="ENVIAR SOLICITUD" ValidationGroup="DatosFiscales" />
                                &nbsp;<asp:Button ID="btnCancelarEditar" runat="server" CssClass="btn btn-blue-grey" OnClick="btnCancelarEditar_Click" TabIndex="15" Text="SALIR" ValidationGroup="Ninguno" />--%>
    <div class="modal fade" id="modalBitacora" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="modBitacora">Bitacora</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body scroll_monitor">
                    <div class="row">
                        <div class="col">
                            <asp:UpdateProgress ID="updPgrBitacora" runat="server"
                                AssociatedUpdatePanelID="updPnlBitacora">
                                <ProgressTemplate>
                                    <asp:Image ID="imgGridEmp" runat="server"
                                        AlternateText="Espere un momento, por favor.." Height="50px"
                                        ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif"
                                        ToolTip="Espere un momento, por favor.." />
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col">
                            <asp:UpdatePanel ID="updPnlBitacora" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="grdBitacora" Width="100%" runat="server" AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="No se encontraron datos...">
                                        <Columns>
                                            <asp:BoundField DataField="DESC_RECEPTOR_STATUS" HeaderText="Status" />
                                            <asp:BoundField DataField="RECEPTOR_FECHA_STATUS" HeaderText="Fecha" />
                                        </Columns>
                                        <FooterStyle CssClass="enc" />
                                        <HeaderStyle CssClass="enc" />
                                        <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                        <SelectedRowStyle CssClass="sel" />
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="modalEMail" tabindex="-1" role="dialog" aria-labelledby="modalEMail" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="modEMail">Enviar facturas</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col text-center">
                                <asp:UpdatePanel ID="UpdatePanel35" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lblMensajeCorreo" runat="server" Font-Bold="True" Font-Size="16px"></asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-2">
                                <asp:UpdatePanel ID="UpdatePanel36" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lblCorreo" runat="server" Text="Correo:"></asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-md-10">
                                <asp:UpdatePanel ID="UpdatePanel34" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="txtCorreo" runat="server" Width="90%"></asp:TextBox>
                                        <br />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtCorreo" CssClass="MsjError" ErrorMessage="*Requerido" ValidationGroup="correo"></asp:RequiredFieldValidator>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col text-center">
                                <asp:UpdateProgress ID="UpdateProgress12" runat="server" AssociatedUpdatePanelID="UpdatePanel37">
                                    <ProgressTemplate>
                                        <asp:Image ID="Image88" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col text-center">
                                <asp:UpdatePanel ID="UpdatePanel37" runat="server">
                                    <ContentTemplate>
                                        <asp:Button ID="bttnCorreo" runat="server" CssClass="btn btn-info" Height="40px" OnClick="bttnCorreo_Click" Text="Enviar" ValidationGroup="correo" />
                                        <%--&nbsp;<asp:Button ID="bttnCancelarCorreo" runat="server" CssClass="btn btn-blue-grey" Height="40px" OnClick="bttnCancelarCorreo_Click" Text="Salir" />--%>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="modal fade" id="modalFacturas" tabindex="-1" role="dialog" aria-labelledby="modalFact" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="modFacturas">Documentos</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body scroll_monitor">
                    <div class="row">
                        <div class="col">
                            <asp:UpdateProgress ID="updPgrFacturas" runat="server"
                                AssociatedUpdatePanelID="updPnlFacturas">
                                <ProgressTemplate>
                                    <asp:Image ID="imgGridFacturas" runat="server"
                                        AlternateText="Espere un momento, por favor.." Height="50px"
                                        ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif"
                                        ToolTip="Espere un momento, por favor.." />
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col">
                            <asp:UpdatePanel ID="updPnlFacturas" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="grdDoctosFactura" runat="server" AutoGenerateColumns="False" CssClass="mGrid" Width="100%" BackColor="#CCCCCC">
                                        <Columns>
                                            <asp:BoundField DataField="TIPO" HeaderText="TIPO" />
                                            <asp:TemplateField HeaderText="ARCHIVO">
                                                <ItemTemplate>
                                                    <asp:HyperLink ID="linkDocto" runat="server" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "RUTA_ADJUNTO") %>' Target="_blank"><%# DataBinder.Eval(Container.DataItem, "NUM_OFICIO") %></asp:HyperLink>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <FooterStyle CssClass="enc" />
                                        <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                        <SelectedRowStyle CssClass="alert-info" />
                                        <HeaderStyle CssClass="enc" />
                                        <AlternatingRowStyle CssClass="alt" />
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="modal" tabindex="-1" role="dialog" id="modalConfirmacion">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Confirmar Solicitud</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="container-fluid">
                        <div class="row" id="rowConfSol" runat="server">
                            <div class="col font-weight-bold alert alert-danger">
                                <asp:UpdatePanel ID="UpdatePanel20" runat="server">
                                    <ContentTemplate>
                                        <asp:CheckBox ID="chkConfirmaSolicitud" runat="server" Text="*Si los datos ya han sido corregidos, puede CONFIRMAR LA SOLICITUD" ValidationGroup="EnviarSol" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <asp:CustomValidator ID="valCheck" runat="server" ClientValidationFunction="ValidateCheckBox" ErrorMessage="*Confirmar Solicitud" ForeColor="Red" ValidationGroup="EnviarSol">*Requerido</asp:CustomValidator>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:LinkButton ID="linkBttnEnviarSol_modal" runat="server" CssClass="btn btn-primary" ValidationGroup="EnviarSol" OnClick="linkBttnEnviarSol_modal_Click"><i class="fa fa-paper-plane" aria-hidden="true"></i> Si</asp:LinkButton>
                    <button type="button" class="btn btn-blue-grey" data-dismiss="modal">No</button>
                </div>
            </div>
        </div>
    </div>
    <div class="modal" tabindex="-1" role="dialog" id="modalSinConfirmacion">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Aviso</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <p class="text-center">
                        <img src="../Imagenes/clock.PNG" />
                    </p>
                    <p>
                        La solicitud capturada se guardo exitosamente, le recordamos que tiene 72 horas para <strong>ENVIAR LA SOLICITUD </strong>de factura,
        pasado este tiempo la solicitud sera eliminada del servicio.
                    </p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-blue-grey" data-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>
    <div class="modal" tabindex="-1" role="dialog" id="modalBorrar">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Cancelación de Factura</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col">Motivo</div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:DropDownList ID="ddlMotivoCancelacion2" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="00">--Seleccionar--</asp:ListItem>
                                    <asp:ListItem Value="CNC001">COMPROBANTES EMITIDOS CON ERRORES CON RELACIÓN</asp:ListItem>
                                    <asp:ListItem Value="CNC002">COMPROBANTES EMITIDOS SIN ERRORES CON RELACIÓN</asp:ListItem>
                                    <asp:ListItem Value="CNC003">NO SE LLEVO OPERACIÓN</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">Observaciones</div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:TextBox ID="txtObservacionesCancela" runat="server" Height="67px" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col text-right">
                                <asp:LinkButton ID="bttnCancelaFact" class="btn btn-primary" runat="server" OnClick="bttnSolCancelaFact_Click">Solicitar cancelación</asp:LinkButton>
                                <button type="button" class="btn btn-blue-grey" data-dismiss="modal">Cerrar</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="modal" tabindex="-1" role="dialog" id="modalAcuse">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">Confirmar aceptar cancelación</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="container-fluid">
                        <asp:UpdatePanel ID="UpdatePanel23" runat="server">
                            <ContentTemplate>
                                <div class="row">
                                    <div class="col">
                                        Acuse
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col">
                                        <div class="input-group mb-3">
                                            <div class="custom-file input-group-text" style="background-color: #ffffff">
                                                <asp:FileUpload ID="fileAcuse" runat="server" Height="40px" Width="100%" />
                                            </div>
                                            <div class="input-group-prepend">
                                                <asp:LinkButton ID="linkBttnAcuse" runat="server" ValidationGroup="guardar" OnClick="linkBttnAcuse_Click" CssClass="input-group-text text-white"><i class="fa fa-arrow-circle-up" aria-hidden="true"></i>Adjuntar</asp:LinkButton>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-10">
                                        <asp:HyperLink ID="linkAcuse" runat="server" CssClass="form-control alert-secondary" Target="_blank">[lblArchivoConstancia]</asp:HyperLink>
                                    </div>
                                    <div class="col-md-2">
                                        <asp:UpdatePanel ID="UpdatePanel22" runat="server">
                                            <ContentTemplate>
                                                <asp:LinkButton ID="linkBttnEliminarAcuse" runat="server" CssClass="btn btn-danger" CausesValidation="False" CommandName="Click" OnClick="linkBttnEliminarConstancia_Click" OnClientClick="return confirm('¿Desea eliminar el registro?');"><i class="fa fa-trash" aria-hidden="true"></i></asp:LinkButton>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="linkBttnAcuse" />
                            </Triggers>
                        </asp:UpdatePanel>

                    </div>
                </div>
                <div class="modal-footer">
                    <div class="container-fluid">
                        <div class="row">
                            <div class="col text-right">
                                <asp:LinkButton ID="linkBttnRechazarSol" class="btn btn-danger" runat="server" OnClick="linkBttnRechazarSol_Click">Rechazar</asp:LinkButton>
                                <asp:LinkButton ID="LinkButton2" class="btn btn-primary" runat="server" OnClick="bttnCancelaFact_Click">Confirmar</asp:LinkButton>
                                <button type="button" class="btn btn-blue-grey" data-dismiss="modal">Cerrar</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript"> 

        function Referencias() {
            $('#<%= grdDatosFactura.ClientID %>').prepend($("<thead></thead>").append($('#<%= grdDatosFactura.ClientID %>').find("tr:first"))).DataTable({
                "destroy": true,
                "stateSave": true,
                "ordering": false
            });
        };

        function ReferenciasEfect() {
            $('#<%= grdDatosFacturaEfect.ClientID %>').prepend($("<thead></thead>").append($('#<%= grdDatosFacturaEfect.ClientID %>').find("tr:first"))).DataTable({
                "destroy": true,
                "stateSave": true,
                "ordering": false
            });
        };

        function ConceptosDisponibles() {
            $('#<%= grvConceptosDisp.ClientID %>').prepend($("<thead></thead>").append($('#<%= grvConceptosDisp.ClientID %>').find("tr:first"))).DataTable({
                "destroy": true,
                "stateSave": true
            });
        }

        function VerCollapse1() {
            $('#collapse1').show();
        }

        function OcultarCollapse1() {
            $('#collapse1').hide();
        }
        function VerCollapse2() {
            $('#collapse2').show();
        }

        function OcultarCollapse2() {
            $('#collapse2').hide();
        }
        function VerCollapse3() {
            $('#collapse3').show();
        }

        function OcultarCollapse3() {
            $('#collapse3').hide();
        }

        function Collapse1() {
            $('#collapseOne').addClass("show");
            <%--if ($('#<%= chkIvaDes.ClientID %>').prop('checked')) {         
                $('#collapseOne').addClass("show");
            }
            else {
                $('#collapseOne').addClass("hide");
            }--%>
        }

        function Collapse2() {
            $(location).href("#collapse2");
        }

        function Collapse3() {
            $('#collapseTres').addClass("show");
        }

        $('#collapseOne').collapse({
            toggle: false
        })

        function Collapse4() {
            $('#collapse4').addClass("show");
        };

        function ValidaConstancia(source, arguments) {
            var Valor
            Valor = arguments.Value;
            //Valor = Valor.substr(3);
            if (Valor.length = 0) {
                arguments.IsValid = false;
            } else {
                arguments.IsValid = true;
            }

        };
    </script>
</asp:Content>
