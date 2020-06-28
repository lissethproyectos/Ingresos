<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmRedirect_SysUsuarios.aspx.cs" Inherits="Recibos_Electronicos.Form.frmRedirect_SysUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
      <%--  function RedirectSys() {
            $('#<%= mp_sistema.ClientID %>').attr("name", "mp_sistema");
            $('#<%= mp_subsistema.ClientID %>').attr("name", "mp_subsistema");
            $('#<%= mp_usuario.ClientID %>').attr("name", "mp_usuario");
            $('#<%= mp_nombre_sistema.ClientID %>').attr("name", "mp_nombre_sistema");
            document.getElementById('<%= Master.Page.Controls[0].FindControl("form1").ClientID %>').action = "https://sysweb.unach.mx/SysUsuarios/Usuarios/Index";
            document.getElementById('<%= Master.Page.Controls[0].FindControl("form1").ClientID %>').method = "POST";
            document.getElementById('<%= Master.Page.Controls[0].FindControl("form1").ClientID %>').submit();
        }--%>

        function RedirectSysUsuarios(Sistema, Usuario, NombreSistema) {
            //$("#loading").show();
            $('#frmUsuarios').attr('src', 'https://sysweb.unach.mx/SysUsuarios/Usuarios/Index?sistema=' + Sistema + '&usuario=' + Usuario + '&nombreSistema=' + NombreSistema);
            $('#frmUsuarios').reload();
            //$("#loading").hide();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<%--            <asp:HiddenField ID="mp_sistema" runat="server"/>
            <asp:HiddenField ID="mp_subsistema" runat="server"/>
            <asp:HiddenField ID="mp_usuario" runat="server"/>
            <asp:HiddenField ID="mp_nombre_sistema" runat="server"/>
            <br />--%>
    <table style="width: 100%;">
       <%-- <tr>
            <td align="center">
                <div id="loading"><asp:Image ID="Image4" runat="server" AlternateText="Espere un momento, por favor.." Height="50px" ImageUrl="https://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif" ToolTip="Espere un momento, por favor.." />
</div>
            </td>
        </tr>--%>
        <tr>
            <td>
                <iframe id="frmUsuarios" style="width: 100%; height: 700px" frameborder="NO" name="I1"></iframe>
            </td>           
        </tr>
    </table>

</asp:Content>
