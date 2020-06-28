<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Recibos.ascx.cs" Inherits="Recibos_Electronicos.ControlUsuario.WebUserControl1" %>
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
  
    .mGrid a{
      color:#0098CB;
    text-decoration:none;
}
  
    a{
    color:#0098CB;
    text-decoration:none;
}

    .mGrid .alt {  
      background:#F2F2F2; /*  td alternado */
    }  
  
      .auto-style2 {
        width: 307px;
        height: 22px;
    }
    .auto-style3 {
        height: 22px;
    }
    .auto-style4 {
        width: 1096px;
    }
</style>

<table style="width:100%;">
    <tr>
        <td>
            <table style="width:100%;">
                <tr>
                    <td class="auto-style3">
                                                        <asp:Label ID="lblFecha_Factura_Ini" runat="server" Text="Fecha Inicial:"></asp:Label>
                                                    </td>
                    <td class="auto-style2">
                                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                            <ContentTemplate>
                                                        <asp:TextBox ID="txtFecha_Factura_Ini" runat="server" AutoPostBack="True" CssClass="box" onkeyup="javascript:this.value='';" Width="95px"></asp:TextBox>
                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtenderIni" runat="server" TargetControlID="txtFecha_Factura_Ini" PopupButtonID="imgCalendarioIni" />
                                                        <asp:ImageButton ID="imgCalendarioIni" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />                                                        
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                    <td class="auto-style3">
                                                        <asp:Label ID="lblFecha_Factura_Fin" runat="server" Text="Fecha Final:"></asp:Label>
                                                    </td>
                    <td class="auto-style3">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                                                        <asp:TextBox ID="txtFecha_Factura_Fin" runat="server" AutoPostBack="True" CssClass="box" onkeyup="javascript:this.value='';" style="margin-left: 0px" Width="95px"></asp:TextBox>
                                                         <ajaxToolkit:CalendarExtender ID="CalendarExtenderFin" runat="server" PopupButtonID="imgCalendarioFin" TargetControlID="txtFecha_Factura_Fin" />
                                                         <asp:ImageButton ID="imgCalendarioFin" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/calendario.gif" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                                                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                                                                <table style="padding: 0px; margin: 0px; width:100%; border-collapse: collapse;">
                                                                    <tr>
                                                                        <td class="auto-style4" valign="top">
                                                                            <asp:TextBox ID="txtReferencia" runat="server" CssClass="box" PlaceHolder="Referencia/Nombre" Visible="true" Width="98%"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:ImageButton ID="imgBttnBuscar" runat="server" ImageUrl="https://sysweb.unach.mx/resources/imagenes/buscar.png" onclick="imgBttnBuscar_Click" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>             
                <asp:UpdatePanel ID="UpdatePanelGrid" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="grdDatosFactura" runat="server" OnSelectedIndexChanged="grdDatosFactura_SelectedIndexChanged"
                            EmptyDataText="El banco no reporto pagos, para el rango de fecha especificado..."
                            DataKeyNames="ID_FACT"                             
                            AutoGenerateColumns="False" AllowPaging="True"                            
                            OnPageIndexChanging="grdDatosFactura_OnPageIndexChanging" CssClass="mGrid" Width="100%" PageSize="20">                            
                            <Columns>
                                <asp:BoundField DataField="ID_FACT" HeaderText="ID" SortExpression="ID"></asp:BoundField>
                                <asp:BoundField DataField="FACT_FOLIO" HeaderText="Folio" SortExpression="FOLIO">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FACT_REFERENCIA" HeaderText="Referencia" SortExpression="REFERENCIA">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FACT_FECHA_FACTURA" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Fecha"
                                    SortExpression="FECHA_FACTURA">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FACT_TOTAL"  DataFormatString="{0:c}" ItemStyle-HorizontalAlign="Right" HeaderText="Importe" SortExpression="Importe">
                                    <HeaderStyle HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FACT_NOMBRE" HeaderText="Nombre" SortExpression="NOMBRE">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FACT_DEPENDENCIA" HeaderText="Dep." SortExpression="DEPENDENCIA">
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Enviar Recibo">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgBttnCorreo" runat="server" ImageUrl="~/Imagenes/correo2.png"/>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:CommandField SelectText="Ver" ShowSelectButton="True" 
                                    HeaderText="Ver Recibo" ButtonType="Image" SelectImageUrl="~/Imagenes/recibo2.png">
                                    <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:CommandField>
                                <asp:TemplateField >
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server"  Text="Editar" ForeColor="Black" ID="btnEditar"></asp:LinkButton>
                                        <%--<asp:ImageButton AlternateText="Editar" OnClick="btnEditar_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "ID_FACT") %>' CommandName='<%# DataBinder.Eval(Container.DataItem, "FACT_NOMBRE") %>'
                                            ImageUrl="~/Imagenes/files_edit.png" ID="btnEditar" runat="server"></asp:ImageButton>--%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="FACT_MATRICULA" />
                            </Columns>
                           <FooterStyle CssClass="enc" />
                                                <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                <SelectedRowStyle CssClass="sel" />
                                                <HeaderStyle CssClass="enc" />                                                
                                                <AlternatingRowStyle CssClass="alt" />   
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
    </tr>
</table>

