<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FrmFacturas.aspx.cs" Inherits="Recibos_Electronicos.Form.FrmFacturas" %>

<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>

<%@ Register Src="../EnviarCorreo.ascx" TagName="uccorreo" TagPrefix="usr" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script language="javascript">
        //Creo una función que imprimira en la hoja el valor del porcentanje asi como el relleno de la barra de progreso
        function callprogress(vValor) {
            //vValor = vValor + 40;
            document.getElementById("getProgressBarFill").style.width = vValor + '%';
            document.getElementById("getProgressBarFill").innerHTML = vValor + '%';
        }

        function LoadPDF(ruta) {
            //valor = '../Facturas/PDF/' + valor + '.pdf';
            alert("paso");
            window.open(ruta, '_blank');
        }

        function LoadXML(valor) {
            valor = '../Facturas/XML/' + valor + '.xml';
            window.open(valor, '',
                'scrollbars=no,menubar=no,height=600,width=800,resizable=yes,toolbar=no,location=no,status=no');
        }

        function LoadPDF_Nuevo(valor) {
            alert("pasa");
            valor = '../Facturas/PDF/' + valor;
            window.open(valor, '',
                'scrollbars=no,menubar=no,height=600,width=800,resizable=yes,toolbar=no,location=no,status=no');
        }

        function LoadXML_Nuevo(valor) {
            //alert(valor);
            valor = '../Facturas/XML/' + valor;
            window.open(valor, '',
                'scrollbars=no,menubar=no,height=600,width=800,resizable=yes,toolbar=no,location=no,status=no');
        }

       <%-- function ValidateCheckBox(sender, args) {

            //alert(document.getElementById('<%=chkConfirmaSolicitud.ClientID %>').checked);
            if (document.getElementById('<%=chkConfirmaSolicitud.ClientID %>').checked == true) {
                args.IsValid = true;
            } else {
                args.IsValid = false;
            }
        }--%>


        function ValidateTipoPersona(sender, args) {
            var RBL = document.getElementById('<%=rdoBttnReceptorTipoPersona.ClientID %>');
            var radiobuttonlist = RBL.getElementsByTagName("input");
            var counter = 0;
            var atLeast = 1
            for (var i = 0; i < radiobuttonlist.length; i++) {
                if (radiobuttonlist[i].checked) {
                    if (radiobuttonlist[i].value == "F") {
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
                }
            }
        }
    </script>




    <style type="text/css">
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
            background-color: #757575;
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="row">
            <div class="col text-center">
                <asp:UpdateProgress ID="UpdateProgress4" runat="server" AssociatedUpdatePanelID="UpdatePanel11">
                    <ProgressTemplate>
                        <asp:Image ID="Image85" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
        </div>
    </div>
    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
        <ContentTemplate>
            <asp:MultiView ID="mltViewFacturas" runat="server">
                <asp:View ID="Datos" runat="server">
                    <div class="container">
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
                        <br />
                        <div class="row">
                            <div class="col-md-1">
                                Tipo
                            </div>
                            <div class="col-md-3">
                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlTipo" runat="server" Width="100%" OnSelectedIndexChanged="ddlTipo_SelectedIndexChanged" AutoPostBack="True">
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

                                <asp:DropDownList ID="ddlFiltro" runat="server" Width="100%">
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
                                        <asp:DropDownList ID="ddlStatus" runat="server" Width="100%" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <hr />
                        <div class="row">
                            <div class="col-md-1">
                                Depcia
                            </div>
                            <div class="col-md-11">
                                <asp:DropDownList ID="ddlDependencia" runat="server" Width="100%">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="ddlDependencia" ErrorMessage="*Dependencia" InitialValue="00000" ValidationGroup="New">*Requerido</asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-1">
                                Del
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtFecha_Factura_Ini" runat="server" CssClass="box" MaxLength="10" Width="95px"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="txtFecha_Factura_Ini_CalendarExtender" runat="server" PopupButtonID="imgCalendarioIni" TargetControlID="txtFecha_Factura_Ini" />
                                <asp:ImageButton ID="imgCalendarioIni" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                            </div>
                            <div class="col-md-1">
                                al
                            </div>
                            <div class="col-md-2">
                                <asp:TextBox ID="txtFecha_Factura_Fin" runat="server" CssClass="box" MaxLength="10" Width="95px"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="txtFecha_Factura_Fin_CalendarExtender" runat="server" PopupButtonID="imgCalendarioFin" TargetControlID="txtFecha_Factura_Fin" />
                                <asp:ImageButton ID="imgCalendarioFin" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                            </div>
                            <div class="input-group col-md-6">
                                <asp:TextBox ID="txtReferencia" runat="server" CssClass="form-control" PlaceHolder="Referencia/Nombre"></asp:TextBox>
                                <div class="input-group-append">
                                    <span class="input-group-text_buscar" id="basic-addon2">
                                        <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                            <ContentTemplate>
                                                <asp:LinkButton ID="linkBttnBuscar" runat="server" class="btn-buscar btn-primary" OnClick="linkBttnBuscar_Click" Width="30px"><i class="fa fa-search" aria-hidden="true"></i></asp:LinkButton>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </span>
                                </div>
                            </div>
                        </div>
                        <%--<div class="row">
                            <div class="col-md-8 font-weight-bold">
                            </div>
                            <div class="col-md-1 font-weight-bold">
                                Solicitado
                            </div>
                            <div class="col-md-1">
                                <asp:Image ID="Image2" runat="server" ImageUrl="~/Imagenes/ejemp_validado.png" Height="35px" Width="35px" />
                            </div>
                            <div class="col-md-1 font-weight-bold">
                                Rechazado
                            </div>
                            <div class="col-md-1">
                                <asp:Image ID="Image3" runat="server" ImageUrl="~/Imagenes/ejem_rechazado.png" Height="35px" Width="35px" />
                            </div>
                        </div>--%>
                    </div>
                    <asp:DropDownList ID="ddlAvance" runat="server" Visible="False">
                    </asp:DropDownList>
                    <asp:HiddenField ID="hddnBandera" runat="server" />
                    <div class="container">
                        <div class="row">
                            <div class="col">
                                <asp:MultiView ID="mltViewTipo" runat="server">
                                    <asp:View ID="View1" runat="server">
                                        <asp:Panel ID="pnlMsg" runat="server" Width="40%">
                                            <div class="card text-white bg-dark mb-3">
                                                <div class="card-header">
                                                    ¿Desea cambiar estatus de la solicitud?
                                                </div>
                                                <div class="card-body">
                                                    <div class="container">
                                                        <div class="row">
                                                            <div class="col text-center">
                                                                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                                                    <ContentTemplate>
                                                                        <br />
                                                                        &nbsp;&nbsp;<asp:Button ID="btnSi" runat="server" CssClass="btn btn-info" Height="40px" OnClick="btnSi_Click" Text="Si" Width="70px" />
                                                                        &nbsp;<asp:Button ID="btnNo" runat="server" CssClass="btn btn-blue-grey" Height="40px" Text="No" Width="70px" OnClick="btnNo_Click" />
                                                                        <br />
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </asp:Panel>
                                        <asp:HiddenField ID="hddnModal" runat="server" />
                                        <ajaxToolkit:ModalPopupExtender ID="ModalPopup" runat="server" BackgroundCssClass="modalBackground_Proy" PopupControlID="pnlMsg" TargetControlID="hddnModal">
                                        </ajaxToolkit:ModalPopupExtender>
                                        <asp:Panel ID="pnlOpcConfirma" runat="server" Visible="False">
                                            <asp:RadioButtonList ID="rdoStatusConfirmados" runat="server" AutoPostBack="True" Font-Bold="True" Font-Size="12px" OnSelectedIndexChanged="rdoStatusConfirmados_SelectedIndexChanged" RepeatDirection="Horizontal" Width="95%" Height="19px" Visible="False">
                                                <asp:ListItem Value="T" Selected="True">&nbsp;TODOS</asp:ListItem>
                                                <asp:ListItem Value="N">&nbsp;(1). FALTA POR CONFIRMAR</asp:ListItem>
                                                <asp:ListItem Value="S">&nbsp;(2). CONFIRMADOS</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </asp:Panel>

                                        <div class="row">
                                            <div class="col">
                                                <asp:UpdatePanel ID="UpdatePanel13" runat="server">
                                                    <ContentTemplate>
                                                        <br />
                                                        <asp:GridView ID="grdDatosFactura" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="3" CssClass="mGrid" DataKeyNames="Id_Fact" EmptyDataText="No existen facturas, para el rango de fecha especificado..." OnPageIndexChanging="grdDatosFactura_OnPageIndexChanging" OnSelectedIndexChanged="grdDatosFactura_SelectedIndexChanged" PageSize="15" Width="100%" OnRowDeleting="grdDatosFactura_RowDeleting" ShowHeaderWhenEmpty="True">
                                                            <Columns>
                                                                <asp:BoundField DataField="Id_Fact" HeaderText="Id_Fact" SortExpression="ID"></asp:BoundField>
                                                                <asp:BoundField DataField="FACT_FOLIO" HeaderText="Folio" SortExpression="FOLIO">
                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="FACT_REFERENCIA" HeaderText="Referencia" SortExpression="REFERENCIA">
                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="FACT_TOTAL" DataFormatString="{0:c}" HeaderText="Importe" ItemStyle-HorizontalAlign="Right" SortExpression="Importe">
                                                                    <HeaderStyle HorizontalAlign="Right" />
                                                                    <ItemStyle HorizontalAlign="Right" />
                                                                    <ControlStyle Width="30px" />
                                                                    <HeaderStyle Width="30px" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="FACT_CLIENTE" HeaderText="Nombre">
                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="FACT_NOMBRE" HeaderText="Beneficiario Factura" SortExpression="NOMBRE">
                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="FACT_DEPENDENCIA" HeaderText="Depen" SortExpression="DEPENDENCIA">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="FACT_BANCO" HeaderText="Banco" >
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                                                                <asp:BoundField DataField="FACT_FECHA_CAPTURA" HeaderText="Fecha Solicitud">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                    <ControlStyle Width="20px" />
                                                                    <HeaderStyle Width="20px" />
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="FACT_FECHA_FACTURA" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha Factura" SortExpression="FECHA_FACTURA">
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                    <ControlStyle Width="20px" />
                                                                    <HeaderStyle Width="20px" />
                                                                </asp:BoundField>
                                                                <asp:TemplateField HeaderText="# Dias Solicitud">
                                                                    <ItemTemplate>
                                                                        <asp:Button ID="bttnDiasSol" runat="server" Text='<%# Bind("FACT_DIAS_SOLICITUD") %>' CssClass="btn-floating btn-sm btn-warning" Style='left: 0px; top: 0px; width: 35px; height: 35px' Visible='<%# Bind("VISIBLE4") %>' />
                                                                        <asp:Button ID="bttnDiasSol2" runat="server" Text='<%# Bind("FACT_DIAS_SOLICITUD") %>' CssClass="btn-floating btn-sm btn-danger" Style='left: 0px; top: 0px; width: 35px; height: 35px' Visible='<%# Bind("VISIBLE5") %>' />
                                                                        <%--<asp:LinkButton ID="LinkButton1" runat="server" Text=' <%# Bind("FACT_DIAS_SOLICITUD") %> ' CssClass="btn-floating btn-sm btn-warning"></asp:LinkButton>--%>
                                                                    </ItemTemplate>
                                                                    <ControlStyle Width="20px" />
                                                                    <HeaderStyle Width="20px" />
                                                                    <ItemStyle Font-Bold="True" HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Status">
                                                                    <HeaderTemplate>
                                                                        <asp:Button ID="btnConfirmar_Sol" runat="server" CssClass="btn btn-blue-grey" Height="35px" OnClick="btnConfirmar_Sol_Click" Text="CONFIRMAR" Visible="False" />
                                                                        STATUS
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="chkConfirmado" runat="server" AutoPostBack="True" Checked='<%# Convert.ToBoolean(Eval("FACT_CONFIRMADO")) %>' Enabled='<%# Bind("HABILITADO") %>' OnCheckedChanged="chkConfirmado_CheckedChanged" Text="Si" Visible="False" />
                                                                        <%--                                                                        <asp:Image ID="Image89" runat="server" ImageUrl="~/Imagenes/activo.png" Visible='<%# Convert.ToBoolean(Eval("FACT_CONFIRMADO")) %>' />
                                                                        <asp:Image ID="imgRechazado" runat="server" ImageUrl='<%# Bind("Ruta") %>' />--%>
                                                                        <asp:Label ID="lblSol" runat="server" Text='<%# Bind("FACT_DESC_STATUS_SOLICITUD") %>' Font-Bold="True" ForeColor="#333333" Font-Size="8"></asp:Label>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Editar" ShowHeader="False">
                                                                    <HeaderTemplate>
                                                                        <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:Button ID="bttnAdd" runat="server" CssClass="btn btn-blue-grey" Text="Agregar" OnClick="bttnAdd_Click" Visible="False" ValidationGroup="New" />
                                                                                <asp:Label ID="lblEditar" runat="server" ForeColor="White" Text="EDITAR" Visible="False"></asp:Label>
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Select" ImageUrl="https://sysweb.unach.mx/resources/Imagenes/edit.png" Text="Factura" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" Width="20px" Wrap="False" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Eliminar">
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="imgBttnCancelar" runat="server" CommandName="Delete" ImageUrl="https://sysweb.unach.mx/resources/Imagenes/del.png" OnClientClick="return confirm('¿Desea eliminar el registro?');" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                    <ControlStyle Width="20px" />
                                                                    <HeaderStyle Width="20px" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="FACT_RECEPTOR_CORREO" />
                                                                <asp:TemplateField HeaderText="ENVIAR XML/PDF">
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="imgBttnCorreo" runat="server" ImageUrl="https://sysweb.unach.mx/resources/Imagenes/correo2.png" OnClick="imgBttnCorreo_Click" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="ID_FICHA_BANCARIA" />
                                                                <asp:BoundField DataField="FACT_STATUS_CAJA" />
                                                                <asp:BoundField DataField="FACT_RECEPTOR_STATUS" />
                                                                <asp:TemplateField HeaderText="RECIBO">
                                                                    <ItemTemplate>
                                                                        <asp:ImageButton ID="imgBttnRecibo" runat="server" ImageUrl="https://sysweb.unach.mx/resources/Imagenes/recibo2.png" OnClick="imgBttnRecibo_Click" />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="RECHAZADO">
                                                                    <ItemTemplate>
                                                                        <asp:Image ID="imgRechazado2" runat="server" ImageUrl='<%# Bind("Ruta") %>' />
                                                                    </ItemTemplate>
                                                                    <HeaderStyle HorizontalAlign="Center" />
                                                                    <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="FACT_TIPO" />
                                                                <asp:TemplateField HeaderText="DOCUMENTOS">
                                                                    <ItemTemplate>
                                                                        <asp:Button ID="bttnDoctos" runat="server" CssClass="btn btn-blue-grey" Text="Ver" OnClick="bttnDoctos_Click" />
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="FACT_DIAS_SOLICITUD" />
                                                            </Columns>
                                                            <FooterStyle CssClass="enc" />
                                                            <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                            <SelectedRowStyle CssClass="sel" />
                                                            <HeaderStyle CssClass="enc" />
                                                            <AlternatingRowStyle CssClass="alt" />
                                                        </asp:GridView>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>

                                        <asp:HiddenField ID="hddnDoctos" runat="server" />
                                        <ajaxToolkit:ModalPopupExtender ID="modalDoctos" runat="server" TargetControlID="hddnDoctos" PopupControlID="pnlDoctos" BackgroundCssClass="modalBackground_Proy">
                                        </ajaxToolkit:ModalPopupExtender>
                                        <asp:Panel ID="pnlDoctos" runat="server" Width="40%">
                                            <div class="card text-white">
                                                <div class="card-header">
                                                    Documentos
                                                </div>
                                                <div class="card-body">
                                                    <div class="container">
                                                        <div class="row">
                                                            <div class="col text-center">
                                                                <asp:GridView ID="grdDoctosFactura" runat="server" AutoGenerateColumns="False" CssClass="mGrid" Width="100%" BackColor="#CCCCCC">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="FACT_TIPO" HeaderText="TIPO" />
                                                                        <asp:TemplateField HeaderText="ARCHIVO">
                                                                            <ItemTemplate>
                                                                                <asp:HyperLink ID="linkDocto" runat="server" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "RUTA_ADJUNTO") %>' Target="_blank"><%# DataBinder.Eval(Container.DataItem, "OFICIO") %></asp:HyperLink>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                    <FooterStyle CssClass="enc" />
                                                                    <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                                    <SelectedRowStyle CssClass="sel" />
                                                                    <HeaderStyle CssClass="enc" />
                                                                    <AlternatingRowStyle CssClass="alt" />
                                                                </asp:GridView>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col text-center">
                                                                <asp:Button ID="bttnSalir" runat="server" CssClass="btn btn-blue-grey" OnClick="bttnSalir_Click" Text="SALIR" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </asp:Panel>
                                    </asp:View>
                                    <asp:View ID="View2" runat="server">
                                    </asp:View>
                                </asp:MultiView>
                            </div>
                        </div>
                    </div>
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
                    <div class="container">
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
                                <asp:ValidationSummary ID="validationSumGuardar" runat="server" CssClass="mensaje_rojo" HeaderText="Los siguientes campos son requeridos:" ValidationGroup="DatosFiscales" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <ajaxToolkit:TabContainer ID="tabFacturas" runat="server" ActiveTabIndex="0" Width="100%" CssClass="mGrid" Height="550px" ScrollBars="Vertical">
                                    <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
                                        <HeaderTemplate>
                                            <i class="fa fa-file-code-o" aria-hidden="true"></i>Información de Factura
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                            <div class="container">
                                                <div class="row">
                                                    <div class="col-md-2">
                                                        RFC
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="input-group mb-3">
                                                            <asp:TextBox ID="txtReceptor_Rfc" runat="server" CssClass="form-control" MaxLength="13"></asp:TextBox>
                                                            <div class="input-group-append">
                                                                <span class="input-group-text_buscar" id="basic-addon2">
                                                                    <asp:Button ID="Button1" runat="server" Text="Buscar" CssClass="btn-buscar btn-primary" OnClick="Button1_Click1" />
                                                                </span>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-2">
                                                        Persona
                                                    </div>
                                                    <div class="col-md-3">
                                                        <asp:UpdatePanel ID="UpdatePanel51" runat="server">
                                                            <ContentTemplate>
                                                                <asp:RadioButtonList ID="rdoBttnReceptorTipoPersona" runat="server" OnSelectedIndexChanged="rdoBttnReceptorTipoPersona_SelectedIndexChanged" RepeatDirection="Horizontal" TabIndex="3" AppendDataBoundItems="True" AutoPostBack="True">
                                                                    <asp:ListItem Value="F">Fisica&#160;&#160;</asp:ListItem>
                                                                    <asp:ListItem Value="M">Moral</asp:ListItem>
                                                                </asp:RadioButtonList>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                        <asp:RequiredFieldValidator ID="valTipoPers" runat="server" ControlToValidate="rdoBttnReceptorTipoPersona" ErrorMessage="*Tipo Persona" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-1">
                                                        <asp:CustomValidator ID="valLongitudRFC0" runat="server" ClientValidationFunction="ValidateTipoPersona" ControlToValidate="rdoBttnReceptorTipoPersona" ErrorMessage="*Para personas Fisicas el RFC debe ser de 13 caracteres, para MORALES de 12 caracteres." ValidationGroup="DatosFiscales">*Faltan datos</asp:CustomValidator>
                                                    </div>

                                                </div>

                                                <div class="row">
                                                    <div class="col-md-2">
                                                        Razón Social
                                                    </div>
                                                    <div class="col-md-10">
                                                        <asp:TextBox ID="txtReceptor_Nombre" runat="server" TabIndex="3" Width="100%"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="valRazon_Social" runat="server" ControlToValidate="txtReceptor_Nombre" ErrorMessage="*Razón Social" ForeColor="Red" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-2">
                                                        Calle
                                                    </div>
                                                    <div class="col-md-4">
                                                        <asp:TextBox ID="txtReceptor_Domicilio" runat="server" MaxLength="500" TabIndex="4" Width="100%"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="valCalle_Fiscal" runat="server" ControlToValidate="txtReceptor_Domicilio" ErrorMessage="*Calle" ForeColor="Red" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-2">
                                                        Colonia
                                                    </div>
                                                    <div class="col-md-4">
                                                        <asp:TextBox ID="txtReceptor_Colonia" runat="server" TabIndex="5" Width="100%"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="valColonia_Fiscal" runat="server" ControlToValidate="txtReceptor_Colonia" ErrorMessage="*Colonia" ForeColor="Red" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-2">
                                                        Estado
                                                    </div>
                                                    <div class="col-md-3">
                                                        <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                                            <ContentTemplate>
                                                                <asp:DropDownList ID="ddlReceptor_Estado" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEstado_Fiscal_SelectedIndexChanged" TabIndex="6" Width="100%">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="ddlReceptor_Estado" ErrorMessage="*Estado" InitialValue="0" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </div>
                                                    <div class="col-md-1">
                                                        Municipio
                                                    </div>
                                                    <div class="col-md-4">
                                                        <asp:DropDownList ID="ddlReceptor_Municipio" runat="server" TabIndex="7" Width="100%">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="ddlReceptor_Municipio" ErrorMessage="*Municipio" InitialValue="0" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-1">
                                                        CP
                                                    </div>
                                                    <div class="col-md-1">
                                                        <asp:TextBox ID="txtReceptor_CP" runat="server" MaxLength="500" TabIndex="8" Width="100%"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="valCP_Fiscal" runat="server" ControlToValidate="txtReceptor_CP" ErrorMessage="*Código Postal" ForeColor="Red" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                                    </div>
                                                </div>

                                                <div class="row">
                                                    <div class="col-md-2">
                                                        Metodo de Pago
                                                    </div>
                                                    <div class="col-md-4">
                                                        <asp:DropDownList ID="ddlReceptor_MetodoPago" runat="server" TabIndex="9" Width="100%">
                                                            <asp:ListItem Value="0">--Seleccionar--</asp:ListItem>
                                                            <asp:ListItem Value="PUE">[PUE] Pago en una sola exhibicion</asp:ListItem>
                                                            <asp:ListItem Value="PPD">[PPD] Pago en parcialidades o diferido</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="valMetodoPago" runat="server" ControlToValidate="ddlReceptor_MetodoPago" ErrorMessage="*Método de Pago" ForeColor="Red" InitialValue="0" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-2">
                                                        Forma de Pago
                                                    </div>
                                                    <div class="col-md-4">
                                                        <asp:DropDownList ID="ddlForma_Pago" runat="server" TabIndex="10" Width="100%">
                                                            <asp:ListItem Value="0">--Seleccionar--</asp:ListItem>
                                                            <asp:ListItem Value="01">[01] Efectivo</asp:ListItem>
                                                            <asp:ListItem Value="02">[02] Cheque Nominativo</asp:ListItem>
                                                            <asp:ListItem Value="03">[03] Transferencia Electrónica de Fondos</asp:ListItem>
                                                            <asp:ListItem Value="04">[04] Tarjeta de Crédito</asp:ListItem>
                                                            <asp:ListItem Value="12">[12] Dacion de Pago</asp:ListItem>
                                                            <asp:ListItem Value="28">[28] Tarjeta de Débito</asp:ListItem>
                                                            <asp:ListItem Value="29">[29] Tarjeta de Servicio</asp:ListItem>
                                                            <asp:ListItem Value="99">[99] Por Definir</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="valFP" runat="server" ControlToValidate="ddlForma_Pago" ErrorMessage="*Requerido" ForeColor="Red" InitialValue="0" ValidationGroup="DatosFiscales"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-2">
                                                        Uso de CFDI
                                                    </div>
                                                    <div class="col-md-4">
                                                        <asp:DropDownList ID="ddlCFDI" runat="server" TabIndex="11">
                                                            <asp:ListItem Value="0">--Seleccionar--</asp:ListItem>
                                                            <asp:ListItem Value="G01">Adquisición de mercancias</asp:ListItem>
                                                            <asp:ListItem Value="G02">Devolución, descuento o bonificaciones</asp:ListItem>
                                                            <asp:ListItem Value="G03">Gastos en general</asp:ListItem>
                                                            <asp:ListItem Value="D04">Donativos</asp:ListItem>
                                                            <asp:ListItem Value="P01">Por definir</asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="valCFDI" runat="server" ControlToValidate="ddlCFDI" ErrorMessage="*Requerido" ForeColor="Red" InitialValue="0" ValidationGroup="DatosFiscales"></asp:RequiredFieldValidator>
                                                    </div>
                                                    <div class="col-md-2">
                                                        Nombre del Servicio
                                                    </div>
                                                    <div class="col-md-4">
                                                        <asp:DropDownList ID="ddlServicio" runat="server" TabIndex="12" Width="100%">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlServicio" ErrorMessage="*Nombre del Servicio" ForeColor="Red" InitialValue="0" ValidationGroup="DatosFiscales" Text="*Requerido"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-2">
                                                        Teléfono
                                                    </div>
                                                    <div class="col-md-4">
                                                        <asp:TextBox ID="txtReceptor_Telefono" runat="server" TabIndex="13" Width="100%"></asp:TextBox>
                                                    </div>

                                                    <div class="col-md-2">
                                                        Correo Electrónico
                                                    </div>
                                                    <div class="col-md-4">
                                                        <asp:TextBox ID="txtReceptor_Correo" runat="server" TabIndex="14" Width="100%"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <br />
                                                <div class="row">
                                                    <div class="col-md-2">
                                                        Descripción
                                                    </div>
                                                    <div class="col-md-10">
                                                        <asp:TextBox ID="txtDescConcepto" runat="server" CssClass="form-control" MaxLength="500" TabIndex="15" PlaceHolder="Detalle del concepto que se requiera en la factura" TextMode="MultiLine"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <br />
                                                <div class="row font-weight-bold" id="rowSolicitarFactura" runat="server">
                                                    <div class="col-md-2">
                                                        Solicitar Factura
                                                    </div>
                                                    <div class="col-md-10">
                                                        <asp:CheckBox ID="chkSolicitar" runat="server" Text="Si" />
                                                    </div>
                                                </div>
                                                <br />
                                                <div class="row">
                                                    <div class="col">
                                                        <asp:CheckBox ID="chkRechazado" runat="server" AutoPostBack="True" Font-Bold="True" Font-Size="14px" OnCheckedChanged="chkRechazado_CheckedChanged" Text="Rechazado" Visible="False" />
                                                    </div>
                                                </div>

                                                <div class="row" id="rowObservaciones" runat="server">
                                                    <div class="col-md-2 font-weight-bold">
                                                        Motivo del Rechazo
                                                    </div>
                                                    <div class="col-md-10">
                                                        <asp:TextBox ID="txtObservaciones" runat="server" Height="67px" TabIndex="13" TextMode="MultiLine" Width="100%"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col">
                                                        <asp:CheckBox ID="chkConfirmaSolicitud" runat="server" CssClass="alert alert-warning" Text="*Si los datos ya han sido corregidos, puede CONFIRMAR LA SOLICITUD" ValidationGroup="DatosFiscales" Visible="False" />
                                                        <asp:CustomValidator ID="valCheck" runat="server" AutoPostBack="False" ClientValidationFunction="ValidateCheckBox" ErrorMessage="*Confirmar Solicitud" ForeColor="Red" ValidationGroup="DatosFiscales">*Requerido</asp:CustomValidator>
                                                    </div>
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                    </ajaxToolkit:TabPanel>
                                    <ajaxToolkit:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3" Width="100%">
                                        <HeaderTemplate>
                                            <i class="fa fa-cog" aria-hidden="true"></i>Detalle
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                            <asp:UpdatePanel ID="UpdatePanel147" runat="server">
                                                <ContentTemplate>
                                                    <div class="container">                                                        
                                                        <div class="row">
                                                            <div class="col">
                                                                <ajaxToolkit:Accordion ID="Accordion1" runat="server" ContentCssClass="alert alert-dark" FadeTransitions="True" FramesPerSecond="50" HeaderCssClass="accordionCabecera" HeaderSelectedCssClass="cssHeaderSelected" Height="700px" RequireOpenedPane="False" SelectedIndex="-1" TransitionDuration="200" Width="100%">
                                                                    <Panes>
                                                                        <ajaxToolkit:AccordionPane runat="server">
                                                                            <Header>
                                                                         Datos del Voucher <i class="fa fa-sticky-note" aria-hidden="true"></i>
                                                                            </Header>
                                                                            <Content>
                                                                                <table style="width: 100%;">
                                                                                    <div class="container">
                                                                                        <div class="row">
                                                                                            <div class="col-md-1">Folio</div>
                                                                                            <div class="col-md-2">
                                                                                                <asp:TextBox ID="txtFolio" runat="server" Width="100px"></asp:TextBox>
                                                                                            </div>
                                                                                            <div class="col-md-1">
                                                                                                <asp:RequiredFieldValidator ID="valFolio" runat="server" ControlToValidate="txtFolio" ErrorMessage="*Folio(Pestania 2)" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                                                                            </div>
                                                                                            <div class="col-md-1">Fecha</div>
                                                                                            <div class="col-md-3">
                                                                                                <asp:TextBox ID="txtFecha" runat="server" Width="100px"></asp:TextBox>
                                                                                                <ajaxToolkit:CalendarExtender ID="txtFecha_CalendarExtender" runat="server" PopupButtonID="imgFecha" TargetControlID="txtFecha" />
                                                                                                <asp:ImageButton ID="imgFecha" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                                                                                                <asp:RequiredFieldValidator ID="valFecha" runat="server" ControlToValidate="txtFecha" ErrorMessage="*Fecha(Pestania 2)" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>

                                                                                            </div>
                                                                                            <div class="col-md-1">Importe</div>
                                                                                            <div class="col-md-2">
                                                                                                <asp:TextBox ID="txtImporte" runat="server"></asp:TextBox>
                                                                                            </div>
                                                                                            <div class="col-md-1">
                                                                                                <asp:RequiredFieldValidator ID="valImporte" runat="server" ControlToValidate="txtImporte" ErrorMessage="*Importe(Pestania 2)" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                    <tr>
                                                                                        <td colspan="10">
                                                                                            <div class="alert-warning">
                                                                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                                                    <ContentTemplate>
                                                                                                        <div class="container">
                                                                                                            <div class="note note-warning" style="font-size: 14px">
                                                                                                                <div class="row">
                                                                                                                    <div class="col">
                                                                                                                        Anexar Voucher
                                                                                                                    </div>
                                                                                                                </div>
                                                                                                                <div class="row">
                                                                                                                    <div class="col">
                                                                                                                        <div class="col font-weight-bold">
                                                                                                                            *Solo formatos PNG, JPG y PDF
                                                                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="fileVoucher" ErrorMessage="Archivo incorrecto, debe ser un PNG, JPG ó PDF" ValidationExpression="(.*?)\.(png|PNG|jpg|JPG|jpeg|JPEG|gif|GIF|pdf|PDF)$" ValidationGroup="guardar"></asp:RegularExpressionValidator>
                                                                                                                        </div>
                                                                                                                    </div>
                                                                                                                </div>
                                                                                                                <div class="row">
                                                                                                                    <div class="col-md-8">
                                                                                                                        <asp:FileUpload ID="fileVoucher" runat="server" Height="30px" />
                                                                                                                    </div>
                                                                                                                    <div class="col-md-4">
                                                                                                                        <asp:Button ID="btnVoucher" runat="server" CssClass="btn btn-blue-grey" OnClick="btnVoucher_Click" Text="ADJUNTAR" ValidationGroup="guardar" />
                                                                                                                    </div>
                                                                                                                </div>
                                                                                                                <div class="row">
                                                                                                                    <div class="col-md-6">
                                                                                                                        <asp:HyperLink ID="lblArchivoVoucher" runat="server" Target="_blank">[lblArchivoVoucher]</asp:HyperLink>
                                                                                                                    </div>

                                                                                                                    <div class="col-md-6">
                                                                                                                        <asp:UpdatePanel ID="UpdatePanel49" runat="server">
                                                                                                                            <ContentTemplate>
                                                                                                                                <asp:LinkButton ID="linkBttnEliminarVoucher" runat="server" CausesValidation="False" CommandName="Click" OnClick="linkBttnEliminarVoucher_Click" OnClientClick="return confirm('¿Desea eliminar el registro?');">ELIMINAR</asp:LinkButton>
                                                                                                                            </ContentTemplate>
                                                                                                                        </asp:UpdatePanel>
                                                                                                                    </div>
                                                                                                                </div>
                                                                                                            </div>
                                                                                                        </div>
                                                                                                    </ContentTemplate>
                                                                                                    <Triggers>
                                                                                                        <asp:PostBackTrigger ControlID="btnVoucher" />
                                                                                                    </Triggers>
                                                                                                </asp:UpdatePanel>
                                                                                            </div>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </Content>
                                                                        </ajaxToolkit:AccordionPane>
                                                                        <ajaxToolkit:AccordionPane runat="server" ID="AccordionPane1" CssClass="note-info">
                                                                            <Header>
                                                                        Datos del Oficio <i class="fa fa-file-text" aria-hidden="true"></i> 
                                                                    </Header>
                                                                            <Content>
                                                                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                                    <ContentTemplate>
                                                                                        <div class="container">
                                                                                            <div class="row">
                                                                                                <div class="col-md-2">
                                                                                                    Núm. de Oficio
                                                                                                </div>
                                                                                                <div class="col-md-3">
                                                                                                    <asp:TextBox ID="txtNumOficio" runat="server"></asp:TextBox>
                                                                                                </div>
                                                                                                <div class="col-md-1">
                                                                                                    <asp:RequiredFieldValidator ID="valNumOficio" runat="server" ControlToValidate="txtNumOficio" ErrorMessage="*Número de Oficio (Pestania 2-&gt;Datos del Oficio)" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                                                                                </div>
                                                                                                <div class="col-md-2">
                                                                                                    Fecha Oficio
                                                                                                </div>
                                                                                                <div class="col-md-4">
                                                                                                    <asp:TextBox ID="txtFechaOficio" runat="server"></asp:TextBox>
                                                                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="ImageButton2" TargetControlID="txtFechaOficio" />
                                                                                                    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                                                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFechaOficio" ErrorMessage="*Fecha Oficio(Pestania 2)" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="container">
                                                                                            <div class="note note-warning" style="font-size: 14px">
                                                                                                <div class="row">
                                                                                                    <div class="col">
                                                                                                        Anexar Oficio
                                                                                                    </div>
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
                                                                                                    <div class="col-md-8">
                                                                                                        <asp:FileUpload ID="fileOficio" runat="server" Height="30px" />
                                                                                                    </div>
                                                                                                    <div class="col-md-4">
                                                                                                        <asp:Button ID="btnOficio" runat="server" CssClass="btn btn-blue-grey" Font-Size="Smaller" OnClick="btnOficio_Click" Text="ADJUNTAR" ValidationGroup="guardar" />
                                                                                                    </div>
                                                                                                </div>
                                                                                                <div class="row">
                                                                                                    <div class="col-md-4">
                                                                                                        <asp:HyperLink ID="lblArchivoOficio" runat="server" Target="_blank">[lblArchivoVoucher]</asp:HyperLink>
                                                                                                    </div>
                                                                                                    <div class="col-md-4">
                                                                                                        <asp:LinkButton ID="linkBttnEliminarOficio" runat="server" CausesValidation="False" CommandName="Click" OnClick="linkBttnEliminarOficio_Click" OnClientClick="return confirm('¿Desea eliminar el registro?');">ELIMINAR</asp:LinkButton>
                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </ContentTemplate>
                                                                                    <Triggers>
                                                                                        <asp:PostBackTrigger ControlID="btnOficio" />
                                                                                    </Triggers>
                                                                                </asp:UpdatePanel>
                                                                            </Content>
                                                                        </ajaxToolkit:AccordionPane>
                                                                        <ajaxToolkit:AccordionPane ID="AccordionPane2" runat="server">
                                                                            <Header>Importe/Convenio <i class="fa fa-money" aria-hidden="true"></i>
                                                                    </Header>
                                                                            <Content>
                                                                                <asp:UpdatePanel ID="updPnlConvenio" runat="server">
                                                                                    <ContentTemplate>
                                                                                        <div class="container">
                                                                                            <div class="row">
                                                                                                <div class="col-md-1">
                                                                                                    Importe
                                                                                                </div>
                                                                                                <div class="col-md-2">
                                                                                                    <asp:TextBox ID="txtImporteConvenio" runat="server" Width="100px"></asp:TextBox>


                                                                                                    <asp:RequiredFieldValidator ID="valImpConvenio" runat="server" ControlToValidate="txtImporteConvenio" ErrorMessage="*Importe (Pestania 2-&gt;Convenio)" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                                                                                </div>
                                                                                                <div class="col-md-2">
                                                                                                    IVA
                                                                                                </div>
                                                                                                <div class="col-md-2">
                                                                                                    <asp:TextBox ID="txtIVA" runat="server" AutoPostBack="True" OnTextChanged="txtIVA_TextChanged" Width="100px"></asp:TextBox>
                                                                                                </div>
                                                                                                <div class="col-md-1">
                                                                                                    <asp:RequiredFieldValidator ID="valIva" runat="server" ControlToValidate="txtIVA" ErrorMessage="*Iva(Pestania 2-&gt;Convenio)" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                                                                                </div>
                                                                                                <div class="col-md-1">
                                                                                                    Total
                                                                                                </div>
                                                                                                <div class="col-md-2">
                                                                                                    <asp:TextBox ID="txtTotal" runat="server" Width="100px"></asp:TextBox>
                                                                                                </div>
                                                                                                <div class="col-md-1">
                                                                                                    <asp:RequiredFieldValidator ID="valTotal" runat="server" ControlToValidate="txtTotal" ErrorMessage="*Total(Pestania 2-&gt;Convenio)" ValidationGroup="DatosFiscales">*Requerido</asp:RequiredFieldValidator>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="row">
                                                                                                <div class="col-md-2">
                                                                                                    Observaciones
                                                                                                </div>
                                                                                                <div class="col-md-10">
                                                                                                    <asp:TextBox ID="txtObservacionesConvenio" runat="server" Height="100px" PlaceHolder="Especificar concepto de la factura, el importe total, en caso de que aplique desglosar IVA." TextMode="MultiLine" Width="90%"></asp:TextBox>
                                                                                                </div>
                                                                                            </div>
                                                                                            <div class="row">
                                                                                                <div class="col">
                                                                                                    <div class="note note-warning" style="font-size: 14px">
                                                                                                        <div class="row">
                                                                                                            <div class="col">
                                                                                                                Anexar Convenio
                                                                                                            </div>
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
                                                                                                                <asp:Button ID="btnConvenio" runat="server" CssClass="btn btn-blue-grey" Font-Size="Smaller" OnClick="btnConvenio_Click" Text="ADJUNTAR" ValidationGroup="guardar" />
                                                                                                            </div>
                                                                                                        </div>

                                                                                                        <div class="row">
                                                                                                            <div class="col-md-10">
                                                                                                                <asp:HyperLink ID="lblArchivoConvenio" runat="server" Target="_blank">[lblArchivoConvenio]</asp:HyperLink>
                                                                                                            </div>
                                                                                                            <div class="col-md-2">
                                                                                                                <asp:LinkButton ID="linkBttnEliminarConvenio" runat="server" CausesValidation="False" CommandName="Click" OnClick="linkBttnEliminarConvenio_Click" OnClientClick="return confirm('¿Desea eliminar el registro?');">ELIMINAR</asp:LinkButton>
                                                                                                                </td>
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
                                                                            </Content>
                                                                        </ajaxToolkit:AccordionPane>

                                                                    </Panes>
                                                                </ajaxToolkit:Accordion>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <br />
                                                    <div class="container">
                                                        <div class="row">
                                                            <div class="col-md-1">
                                                                Nivel
                                                            </div>
                                                            <div class="col-md-5">
                                                                <asp:DropDownList ID="ddlNivel" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlNivel_SelectedIndexChanged" Width="100%">
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col">
                                                                <asp:CustomValidator ID="valConceptos" runat="server" ErrorMessage="*Se debe asignar al menor un concepto" OnServerValidate="ConceptosAsignados" ValidationGroup="DatosFiscales">*Conceptos Requeridos</asp:CustomValidator>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <%--<div class="col-md-6">
                                                                <div class=" alert alert-warning text-center">
                                                                    <strong>CONCEPTOS ASIGNADOS</strong>
                                                                </div>
                                                            </div>--%>
                                                            <%--<div class="col-md-6">
                                                                <div class=" alert alert-warning text-center">
                                                                    <strong>CONCEPTOS DISPONIBLES
                                                                    </strong>
                                                                </div>
                                                            </div>--%>
                                                        </div>

                                                        <div class="row">
                                                            <div class="col-md-6">
                                                                <asp:GridView ID="grvConceptosDisp" runat="server" AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="No se encontro ningún registro" OnPageIndexChanging="grvConceptosDisp_PageIndexChanging" OnSelectedIndexChanged="grvConceptosDisp_SelectedIndexChanged" Width="100%" AllowPaging="True">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="ClaveConcepto" HeaderText="Cve.">
                                                                            <HeaderStyle HorizontalAlign="Left" />
                                                                            <ItemStyle HorizontalAlign="Left" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="Descripcion" HeaderText="Descripción">
                                                                            <HeaderStyle HorizontalAlign="Left" />
                                                                            <ItemStyle HorizontalAlign="Left" Width="70%" />
                                                                        </asp:BoundField>
                                                                        <asp:CommandField SelectText="Agregar" ShowSelectButton="True" />
                                                                    </Columns>
                                                                    <FooterStyle CssClass="enc" />
                                                                    <HeaderStyle CssClass="enc" />
                                                                    <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                                    <SelectedRowStyle CssClass="sel" />
                                                                </asp:GridView>
                                                            </div>
                                                            <div class="col-md-6">
                                                                <asp:GridView ID="grvConceptos" runat="server" AutoGenerateColumns="False" CssClass="mGrid" EmptyDataText="No se encontro ningún registro" OnRowDeleting="grvConceptos_RowDeleting" Width="100%">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="ClaveConcepto" HeaderText="Cve.">
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
                                                                    <HeaderStyle CssClass="enc" />
                                                                    <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                                    <SelectedRowStyle CssClass="sel" />
                                                                </asp:GridView>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </ContentTemplate>
                                    </ajaxToolkit:TabPanel>
                                    <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="Imagen de la Factura">
                                        <HeaderTemplate>
                                            <i class="fa fa-upload" aria-hidden="true"></i>Archivos
                                        </HeaderTemplate>
                                        <ContentTemplate>
                                            <asp:UpdatePanel ID="UpdatePanelFoto" runat="server">
                                                <ContentTemplate>
                                                    <div class="container">
                                                        <div class="row">
                                                            <div class="col-md-2">
                                                                Folio de la Factura
                                                            </div>
                                                            <div class="col-md-2">
                                                                <asp:TextBox ID="txtFolio_Fact_Cja" runat="server" Width="100%"></asp:TextBox>
                                                            </div>
                                                            <div class="col-md-1">
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtFolio_Fact_Cja" ErrorMessage="*Requerido" ValidationGroup="adjuntarFactura"></asp:RequiredFieldValidator>
                                                            </div>
                                                            <div class="col-md-2">
                                                                Fecha de la Factura
                                                            </div>
                                                            <div class="col-md-3">
                                                                <asp:TextBox ID="txtFecha_Fact_Cja" runat="server" AutoPostBack="True" CssClass="box" onkeyup="javascript:this.value='';" Width="95px"></asp:TextBox>
                                                                <ajaxToolkit:CalendarExtender ID="txtFecha_Fact_Cja_CalendarExtender" runat="server" PopupButtonID="imgFecha_Fact_Cja" TargetControlID="txtFecha_Fact_Cja" />
                                                                <asp:ImageButton ID="imgFecha_Fact_Cja" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                                                                &#160;<asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtFecha_Fact_Cja" ErrorMessage="*Requerido" ValidationGroup="adjuntarFactura"></asp:RequiredFieldValidator>
                                                            </div>
                                                        </div>
                                                        <div class="note note-info">
                                                            <div class="row font-weight-bold">
                                                                <div class="col">
                                                                    *Solo formatos PDF Y XML
                                                                </div>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-md-8">
                                                                    <asp:FileUpload ID="fileFactura" runat="server" />
                                                                </div>
                                                                <div class="col-md-2">
                                                                    <asp:Button ID="btnAgregaFactura" runat="server" CssClass="btn btn-blue-grey" OnClick="btnAgregaFactura_Click" Text="ADJUNTAR" ValidationGroup="adjuntarFactura" />
                                                                </div>

                                                                <div class="col-md-2">
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="fileFactura" ErrorMessage="Archivo incorrecto, debe ser un PDF o XML" ValidationExpression="(.*?)\.(xml|XML|pdf|PDF)$" ValidationGroup="guardar"></asp:RegularExpressionValidator>
                                                                </div>
                                                            </div>

                                                        </div>

                                                        <div class="row">
                                                            <div class="col">
                                                                <asp:GridView ID="grdArchivos" runat="server" AutoGenerateColumns="False" CssClass="mGrid" OnRowDeleting="grdArchivos_RowDeleting" Width="100%">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="Fecha_Fact_Cja" HeaderText="Fecha" />
                                                                        <asp:BoundField DataField="Folio_Fact_Cja" HeaderText="Folio" />
                                                                        <asp:BoundField DataField="NombreArchivo" Visible="False" />
                                                                        <asp:TemplateField HeaderText="Archivo">
                                                                            <ItemTemplate>
                                                                                <asp:HyperLink ID="linkPdf" runat="server" NavigateUrl='<%# DataBinder.Eval(Container.DataItem, "Ruta") %>' Target="_blank"><%# DataBinder.Eval(Container.DataItem, "NombreArchivo") %></asp:HyperLink>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:BoundField DataField="ExtensionArchivo" Visible="False" />
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
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:PostBackTrigger ControlID="btnAgregaFactura" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </ContentTemplate>
                                    </ajaxToolkit:TabPanel>
                                </ajaxToolkit:TabContainer>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col text-right">
                                <asp:Button ID="btnGuardarEditar" runat="server" CssClass="btn btn-info" OnClick="btnGuardarEditar_Click" TabIndex="14" Text="GUARDAR" ValidationGroup="DatosFiscales" />
                                &nbsp;<asp:Button ID="btnCancelarEditar" runat="server" CssClass="btn btn-blue-grey" OnClick="btnCancelarEditar_Click" TabIndex="15" Text="CANCELAR" />
                            </div>
                        </div>
                    </div>
                </asp:View>
            </asp:MultiView>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:HiddenField ID="hddnCorreo" runat="server" />
    <ajaxToolkit:ModalPopupExtender ID="modalCorreo" runat="server" BackgroundCssClass="modalBackground_Proy" PopupControlID="pnlCorreo" TargetControlID="hddnCorreo">
    </ajaxToolkit:ModalPopupExtender>


    <asp:Panel ID="pnlCorreo" runat="server" CssClass="TituloModalPopupMsg" Width="65%">
        <div class="card text-white bg-dark mb-3">
            <div class="card-header">
                Enviar Recibo Oficial
            </div>
            <div class="card-body">
                <div class="container">
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
                                    &nbsp;<asp:Button ID="bttnCancelarCorreo" runat="server" CssClass="btn btn-blue-grey" Height="40px" OnClick="bttnCancelarCorreo_Click" Text="Salir" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
        </div>





    </asp:Panel>
</asp:Content>
