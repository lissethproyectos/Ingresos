<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pruebas.aspx.cs" Inherits="Recibos_Electronicos.Form.Pruebas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 90%;" >
        <tr><td style="background-color: #0066CC; color: #FFFFFF">Participante General</td></tr>
        <tr>
            <td align="center">
                <asp:Panel ID="pnlParticipante_Gral" runat="server" BackColor="#99CCFF">                
                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="lblNombre" runat="server" Text="Nombre(s)"></asp:Label>
                    </div>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtNombre" runat="server" TabIndex="1" AutoPostBack="True" OnTextChanged="txtNombre_TextChanged" Width="80%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNombre"
                            ErrorMessage="*Requerido" ForeColor="Red" ValidationGroup="gpoExterno"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="lblPaterno" runat="server" Text="Apellido Paterno"></asp:Label>
                    </div>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtPaterno" runat="server" TabIndex="2" Width="80%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPaterno"
                            ErrorMessage="*Requerido" ForeColor="Red" ValidationGroup="gpoExterno"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="lblMaterno" runat="server" Text="Apellido Materno"></asp:Label>
                    </div>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtMaterno" runat="server" OnTextChanged="txtMaterno_TextChanged"
                            AutoPostBack="True" TabIndex="3" Width="80%"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="lblPeriodo_Pago_G" runat="server" Text="Periodo de Pago (Ciclo)"></asp:Label>
                    </div>
                    <div class="col-md-7">
                        <asp:DropDownList ID="ddlPeriodo_Pago_G" runat="server" TabIndex="4" Width="40%">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="lblGenero" runat="server" Text="Género"></asp:Label>
                    </div>
                    <div class="col-md-7">
                        <asp:RadioButtonList ID="rdoGenero" runat="server" RepeatDirection="Horizontal" TabIndex="5">
                            <asp:ListItem Value="F">Femenino</asp:ListItem>
                            <asp:ListItem Value="M" Selected="True">Masculino</asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="rdoGenero"
                            ErrorMessage="*Requerido" ForeColor="Red" ValidationGroup="gpoExterno"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="lblEdo_Provincia" runat="server" Text="Estado / Provincia"></asp:Label>
                    </div>
                    <div class="col-md-7">
                        <asp:DropDownList ID="ddlEdo_Provincia" runat="server" TabIndex="6" Width="80%">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlEdo_Provincia"
                            ErrorMessage="*Requerido" ForeColor="Red" ValidationGroup="gpoExterno"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="lblCiudad" runat="server" Text="Ciudad"></asp:Label>
                    </div>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtCiudad" runat="server" TabIndex="7" Width="80%"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="lblDomicilio" runat="server" Text="Domicilio"></asp:Label>
                    </div>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtDomicilio" runat="server" TabIndex="8" Width="80%"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="lblColonia" runat="server" Text="Colonia"></asp:Label>
                    </div>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtColonia" runat="server" TabIndex="9" Width="80%"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="lblCP" runat="server" Text="Código Postal"></asp:Label>
                    </div>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtCP" runat="server" TabIndex="10" Width="40%"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="lblTelefono" runat="server" Text="Teléfono"></asp:Label>
                    </div>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtTelefono" runat="server" TabIndex="11" Width="40%"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="lblCel" runat="server" Text="Celular"></asp:Label>
                    </div>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtCel" runat="server" TabIndex="12" Width="40%"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="lblInstitucion" runat="server" Text="Institución"></asp:Label>
                    </div>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtInstitucion" runat="server" TabIndex="13" Width="80%"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="lblCargo_Puesto" runat="server" Text="Cargo o Puesto"></asp:Label>
                    </div>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtCargo_Puesto" runat="server" TabIndex="14" Width="80%"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="lblGrado_Max_Est" runat="server" Text="Grado Máximo de Estudios"></asp:Label>
                    </div>
                    <div class="col-md-7">
                        <asp:DropDownList ID="ddlGrado_Max_Est" runat="server" TabIndex="15" Width="40%">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="lblCorreo" runat="server" Text="Correo Electrónico"></asp:Label>
                    </div>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtCorreo" runat="server" TabIndex="16" Width="40%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txtCorreo" ErrorMessage="*Requerido" ForeColor="Red" ValidationGroup="gpoExterno"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="lblConstancia" runat="server" Text="Nombre para Constancia"></asp:Label>
                    </div>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtConstancia" runat="server" TabIndex="17" Width="80%"></asp:TextBox>
                    </div>
                </div>
                <asp:Panel runat="server" ID="pnlPatrocinador" Visible="false">
                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="lblDonativo_Patrocinador" runat="server" Text="Donativo Patrocinador"></asp:Label>
                    </div>
                    <div class="col-md-7">
                        <div class="input-group">
                            
                                <span class="input-group-addon">$</span>
                                <asp:TextBox ID="txtDonativo_Patrocinador" runat="server" TabIndex="18" Width="30%">0</asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtDonativo_Patrocinador"
                                    ForeColor="Red" ErrorMessage="* Solo Números" ValidationGroup="gpoInterno" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                            
                        </div>
                    </div>
                </div>
                    </asp:Panel>
            </asp:Panel></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlEstudianteUNACH" runat="server" Visible="False">
                
                  <div class="row"> <div class="col-md-3" style="padding-left:40px;"> <asp:Label ID="lblMatricula" runat="server" 
                            Text="No. de Ficha / Matricula / Id Sysweb" Font-Bold="False"></asp:Label> </div> <div class="col-md-4"> <asp:UpdatePanel ID="UpdMatricula" runat="server"><ContentTemplate><asp:TextBox ID="txtMatricula" runat="server"
                                TabIndex="2" MaxLength="8" CausesValidation="True" 
                                ValidationGroup="gpoBusca" placeholder="Ingresa matricula y click en buscar" Width="100%" OnTextChanged="txtMatricula_TextChanged"></asp:TextBox><div class="mensaje_celeste"><asp:Label ID="lblMsjUsu" runat="server"  Text="Si no tienes no. de ficha, matricula o id sysweb, click en el icono de la lupa, y registrate."></asp:Label></div>
                            </ContentTemplate>
                        </asp:UpdatePanel> <asp:UpdateProgress ID="UpdProMatricula" AssociatedUpdatePanelID="UpdMatricula" runat="server"><ProgressTemplate><asp:Image ID="imgMatricula" runat="server" Height="50px" ImageUrl="http://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif"
                                    class="img-responsive" alt="Responsive image" ToolTip="Espere un momento, por favor.." />
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                                 
                          <asp:Panel ID="pnlMsjReg" runat="server"><div class="mensaje_rojo" role="alert"><asp:Label ID="lblMsjReg" runat="server"></asp:Label>&nbsp;<asp:LinkButton ID="btnRegistrar" runat="server" onclick="btnRegistrar_Click" 
                                Visible="False">AQUI</asp:LinkButton></div></asp:Panel> <br /> <asp:Label ID="lblMatRe" runat="server" ForeColor="#2B5D95" Text="Si tienes matrícula ingrésala, en caso contrario continúa con tu registro." 
                                Font-Bold="True" Visible="False"></asp:Label> </div> <div class="col-md-4"> <asp:ImageButton ID="imgBttnBuscar" runat="server" ImageUrl="http://sysweb.unach.mx/resources/imagenes/buscar.png" onclick="imgBttnBuscar_Click" />
                      </div> </div> <div class="row"> <div class="col-md-3"> <asp:UpdatePanel ID="UpdatePanel9" runat="server"><ContentTemplate><asp:Label ID="lblNivel" runat="server" Text="Nivel de Estudios" Visible="False" style="padding-left:40px;"></asp:Label></td>
                            </ContentTemplate>
                        </asp:UpdatePanel> </div> <div class="col-md-7"> <asp:UpdatePanel ID="updPnlNivel" runat="server"><ContentTemplate><asp:ListBox ID="ddlNivel" runat="server" AutoPostBack="True" CausesValidation="True" Height="100px" OnSelectedIndexChanged="ddlNivel_SelectedIndexChanged" ValidationGroup="gpoBusca" Visible="False" Width="40%"></asp:ListBox>
                            </ContentTemplate>
                        </asp:UpdatePanel> <asp:UpdateProgress ID="updProgNivel" AssociatedUpdatePanelID="updPnlNivel" runat="server"><ProgressTemplate><asp:Image ID="imgNivel" runat="server" Height="50px" ImageUrl="http://sysweb.unach.mx/resources/imagenes/ajax_loader_gray_512.gif"
                                    class="img-responsive" alt="Responsive image" ToolTip="Espere un momento, por favor.." />
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                          <br /> <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="ddlNivel" Display="Dynamic" ErrorMessage="Seleccionar Nivel" ForeColor="Red" InitialValue="Z" ValidationGroup="gpoBusca">* Seleccionar Nivel</asp:RequiredFieldValidator> </div> </div> <asp:Panel ID="pnlDatos" runat="server" Visible="False"><div class="row"><div class="col-md-3"><asp:Label ID="lblNombreReg" runat="server" Text="Nombre" style="padding-left:40px;"></asp:Label></div><div class="col-md-7"><asp:TextBox ID="txtNombreReg" runat="server" Enabled="False" TabIndex="3" Width="80%"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtNombreReg"
                            ErrorMessage="*Requerido" ForeColor="Red" ValidationGroup="gpoInterno"></asp:RequiredFieldValidator></div></div><div class="row"><div class="col-md-3"><asp:Label ID="lblPaternoReg" runat="server" Text="Apellido Paterno" style="padding-left:40px;"></asp:Label></div><div class="col-md-7"><asp:TextBox ID="txtPaternoReg" runat="server" TabIndex="4" Width="80%"></asp:TextBox></div></div><div class="row"><div class="col-md-3"><asp:Label ID="lblMaternoReg" runat="server" Text="Apellido Materno" style="padding-left:40px;"></asp:Label></div><div class="col-md-7"><asp:TextBox ID="txtMaternoReg" runat="server"
                            AutoPostBack="True" TabIndex="5" Width="80%"></asp:TextBox></div></div><div class="row"><div class="col-md-3"><asp:Label ID="lblEscuela" runat="server" Text="Escuela" style="padding-left:40px;"></asp:Label></div><div class="col-md-7"><asp:DropDownList ID="ddlDependencia_D" Enabled="False" runat="server" TabIndex="6"
                            ClientIDMode="Predictable" Width="80%" OnSelectedIndexChanged="ddlDependencia_D_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" 
                            ControlToValidate="ddlDependencia_D" ErrorMessage="*Requerido" ForeColor="Red" 
                            InitialValue="0" ValidationGroup="gpoInterno"></asp:RequiredFieldValidator><asp:TextBox ID="txtEscuela" runat="server" Visible="false"></asp:TextBox></div></div><div class="row"><div class="col-md-3"><asp:Label ID="lblCarrera" runat="server" Text="Carrera" style="padding-left:40px;"></asp:Label></div><div class="col-md-7"><asp:DropDownList ID="ddlCarrera" runat="server" ClientIDMode="Predictable" Enabled="False"
                            TabIndex="7" Width="80%" AutoPostBack="True" 
                            onselectedindexchanged="ddlCarrera_SelectedIndexChanged">
                        </asp:DropDownList></div></div><div class="row"><div class="col-md-3"><asp:Label ID="lblOtraCarrera" runat="server" Text="Especificar:" Visible="False" style="padding-left:40px;"></asp:Label></div><div class="col-md-7"><asp:TextBox ID="txtCarrera" runat="server" Visible="false" Enabled="False" placeholder="Escriba el nombre de la carrera" Width="80%"></asp:TextBox></div></div><div class="row"><div class="col-md-3"><asp:Label ID="lblSemestre" runat="server" Text="Semestre" style="padding-left:40px;"></asp:Label></div><div class="col-md-7"><asp:TextBox ID="txtSemestre" runat="server" Enabled="False" TabIndex="8" Width="40%"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtSemestre"
                            ErrorMessage="*Requerido" ForeColor="Red" ValidationGroup="gpoInterno"></asp:RequiredFieldValidator><asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtSemestre"
                            ForeColor="Red" ErrorMessage="* Solo Números" ValidationGroup="gpoInterno" ValidationExpression="\d+"></asp:RegularExpressionValidator></div></div><div class="row"><div class="col-md-3"><asp:Label ID="lblGrupo0" runat="server" Text="Grupo" style="padding-left:40px;"></asp:Label></div><div class="col-md-7"><asp:TextBox ID="txtGrupo" runat="server" Enabled="False" TabIndex="9" 
                            MaxLength="1" Width="40%"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtGrupo"
                            ErrorMessage="*Requerido" ForeColor="Red" ValidationGroup="gpoInterno"></asp:RequiredFieldValidator></div></div><div class="row"><div class="col-md-3"><asp:Label ID="lblPeriodo_Pago_I" runat="server" Text="Periodo de Pago (Ciclo)" style="padding-left:40px;"></asp:Label></div><div class="col-md-7"><asp:DropDownList ID="ddlPeriodo_Pago_I" runat="server" TabIndex="10" Width="40%">
                        </asp:DropDownList><asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="ddlPeriodo_Pago_I" ErrorMessage="*Requerido" ForeColor="Red" InitialValue="0" ValidationGroup="gpoInterno"></asp:RequiredFieldValidator></div></div><div class="row"><div class="col-md-3"><asp:Label ID="Label4" runat="server" Text="Género" style="padding-left:40px;"></asp:Label></div><div class="col-md-7"><asp:RadioButtonList ID="rdoGeneroI" runat="server" RepeatDirection="Horizontal"
                            TabIndex="11"><asp:ListItem Value="F">Femenino</asp:ListItem><asp:ListItem Value="M" Selected="True">Masculino</asp:ListItem>
                        </asp:RadioButtonList></div></div><div class="row"><div class="col-md-3"><asp:Label ID="lblCorreo0" runat="server" Text="Correo Electrónico" style="padding-left:40px;"></asp:Label></div><div class="col-md-7"><asp:TextBox ID="txtCorreo0" runat="server" TabIndex="12" Width="40%"></asp:TextBox><asp:RequiredFieldValidator ID="CampoReqCorreo0" runat="server" ControlToValidate="txtCorreo0" ErrorMessage="*Requerido" ForeColor="Red" ValidationGroup="gpoInterno"></asp:RequiredFieldValidator>&nbsp;<asp:RegularExpressionValidator runat=server ControlToValidate="txtCorreo0" ErrorMessage="*Este correo no es válido"
                                ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$" ValidationGroup="gpoInterno" ForeColor="Red" ID="ExpRegCorreo" />
                    </div>
                </div>
              </asp:Panel>
             </asp:Panel></td> </tr> 
        <tr><td>&nbsp;</td></tr>
        <tr><td style="background-color: #003399; color: #FFFFFF;">PONENTE</td></tr>
        <tr>
            <td>
                <asp:Panel ID="pnlParticipante_Ponente" runat="server" Visible="False">
                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="lblNombre1" runat="server" Text="Nombre(s)" style="padding-left:40px;"></asp:Label>
                    </div>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtNombre1" runat="server" TabIndex="1" Width="80%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtNombre1"
                            ErrorMessage="*Requerido" ForeColor="Red" ValidationGroup="gpoPonente"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="lblPaterno0" runat="server" Text="Apellido Paterno" style="padding-left:40px;"></asp:Label>
                    </div>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtPaterno0" runat="server" TabIndex="2" Width="80%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtPaterno0"
                            ErrorMessage="*Requerido" ForeColor="Red" ValidationGroup="gpoPonente"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="lblMaterno0" runat="server" Text="Apellido Materno" style="padding-left:40px;"></asp:Label>
                    </div>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtMaterno0" runat="server" AutoPostBack="True" OnTextChanged="txtMaterno0_TextChanged"
                            TabIndex="3" Width="80%"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="lblPeriodo_Pago_P" runat="server" Text="Periodo de Pago (Ciclo)" style="padding-left:40px;"></asp:Label>
                    </div>
                    <div class="col-md-7">
                        <asp:DropDownList ID="ddlPeriodo_Pago_P" runat="server" TabIndex="4">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="lblGenero0" runat="server" Text="Género" style="padding-left:40px;"></asp:Label>
                    </div>
                    <div class="col-md-7">
                        <asp:RadioButtonList ID="rdoGenero0" runat="server" RepeatDirection="Horizontal"
                            TabIndex="5">
                            <asp:ListItem Value="F">Femenino</asp:ListItem>
                            <asp:ListItem Value="M" Selected="True">Masculino</asp:ListItem>
                        </asp:RadioButtonList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="rdoGenero0"
                            ErrorMessage="*Requerido" ForeColor="Red" ValidationGroup="gpoPonente"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="lblEdo_Provincia0" runat="server" Text="Estado / Provincia" style="padding-left:40px;"></asp:Label>
                    </div>
                    <div class="col-md-7">
                        <asp:DropDownList ID="ddlEdo_Provincia0" runat="server" TabIndex="6">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="ddlEdo_Provincia0"
                            ErrorMessage="*Requerido" ForeColor="Red" ValidationGroup="gpoPonente"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="lblCiudad0" runat="server" Text="Ciudad" style="padding-left:40px;"></asp:Label>
                    </div>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtCiudad0" runat="server" TabIndex="7" Width="80%"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="lblDomicilio0" runat="server" Text="Domicilio" style="padding-left:40px;"></asp:Label>
                    </div>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtDomicilio0" runat="server" TabIndex="8" Width="80%"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="lblColonia0" runat="server" Text="Colonia" style="padding-left:40px;"></asp:Label>
                    </div>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtColonia0" runat="server" TabIndex="9" Width="80%"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="lblCP0" runat="server" Text="Código Postal"></asp:Label>
                    </div>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtCP0" runat="server" TabIndex="10"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="lblTelefono0" runat="server" Text="Teléfono" style="padding-left:40px;"></asp:Label>
                    </div>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtTelefono0" runat="server" TabIndex="11"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="lblCel0" runat="server" Text="Celular" style="padding-left:40px;"></asp:Label>
                    </div>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtCel0" runat="server" TabIndex="12"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="lblInstitucion0" runat="server" Text="Institución" style="padding-left:40px;"></asp:Label>
                    </div>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtInstitucion0" runat="server" TabIndex="13" Width="80%"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="lblCargo_Puesto0" runat="server" Text="Cargo o Puesto" style="padding-left:40px;"></asp:Label>
                    </div>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtCargo_Puesto0" runat="server" TabIndex="14" Width="80%"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="lblGrado_Max_Est0" runat="server" Text="Grado Máximo de Estudios" style="padding-left:40px;"></asp:Label>
                    </div>
                    <div class="col-md-7">
                        <asp:DropDownList ID="ddlGrado_Max_Est0" runat="server" TabIndex="15">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="lblCorreo1" runat="server" Text="Correo Electrónico" style="padding-left:40px;"></asp:Label>
                    </div>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtCorreo1" runat="server" TabIndex="16"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="lblConstancia1" runat="server" Text="Nombre para Constancia" style="padding-left:40px;"></asp:Label>
                    </div>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtConstancia1" runat="server" TabIndex="17" Width="80%"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="lblPonencia1" runat="server" Text="Ponencia 1"></asp:Label>
                    </div>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtPonencia1" runat="server" TextMode="MultiLine" TabIndex="18" Width="80%"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="lblPonencia2" runat="server" Text="Ponencia 2"></asp:Label>
                    </div>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtPonencia2" runat="server" TextMode="MultiLine" TabIndex="19" Width="80%"></asp:TextBox>
                    </div>
                </div>
            </asp:Panel>
            </td>
        </tr>

        <tr>
            <td>
                &nbsp;</td>
        </tr>

        <tr>
            <td style="background-color: #0066CC; color: #FFFFFF">
                ESTUDIANTE UNACH SIN MATRICULA</td>
        </tr>

        <tr>
            <td>
                <asp:Panel ID="pnlParticiante_InternoSMatricula" runat="server" Visible="False">
                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="Label2" runat="server" Text="Nombre" style="padding-left:40px;"></asp:Label>
                    </div>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtNombre2" runat="server" TabIndex="1" Width="80%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtNombre2"
                            ErrorMessage="*Requerido" ForeColor="Red" ValidationGroup="gpoInternoSM"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="Label12" runat="server" Text="Apellido Paterno" style="padding-left:40px;"></asp:Label>
                    </div>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtPaterno2" runat="server" TabIndex="2" Width="80%"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="Label13" runat="server" Text="Apellido Materno" style="padding-left:40px;"></asp:Label>
                    </div>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtMaterno2" runat="server" AutoPostBack="True" OnTextChanged="txtMaterno2_TextChanged"
                            TabIndex="3" Width="80%"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="Label1" runat="server" Text="Matrícula" style="padding-left:40px;"></asp:Label>
                    </div>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtMatricula2" runat="server" TabIndex="4"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="Label11" runat="server" Text="Genero" style="padding-left:40px;"></asp:Label></td>
                    </div>
                    <div class="col-md-7">
                        <asp:RadioButtonList ID="rdoGenero2" runat="server" RepeatDirection="Horizontal"
                            TabIndex="5">
                            <asp:ListItem Value="F">Femenino</asp:ListItem>
                            <asp:ListItem Value="M" Selected="True">Masculino</asp:ListItem>
                        </asp:RadioButtonList>
                        </td>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="Label3" runat="server" Text="Escuela" style="padding-left:40px;"></asp:Label>
                    </div>
                    <div class="col-md-7">
                        <asp:DropDownList ID="DDLEscuela" runat="server" TabIndex="6" Width="80%">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="Label5" runat="server" Text="Semestre" style="padding-left:40px;"></asp:Label>
                    </div>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtSemestre2" runat="server" TabIndex="7"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtSemestre2"
                            ForeColor="Red" ErrorMessage="* Solo Números" ValidationGroup="gpoInternoSM"
                            ValidationExpression="\d+"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtSemestre2"
                            ErrorMessage="*Requerido" ForeColor="Red" ValidationGroup="gpoInternoSM"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="Label6" runat="server" Text="Grupo" style="padding-left:40px;"></asp:Label>
                    </div>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtGrupo2" runat="server" TabIndex="8"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtGrupo2"
                            ErrorMessage="*Requerido" ForeColor="Red" ValidationGroup="gpoInternoSM"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="Label7" runat="server" Text="Periodo de Pago (Ciclo)" style="padding-left:40px;"></asp:Label>
                    </div>
                    <div class="col-md-7">
                        <asp:DropDownList ID="ddlPeriodo_Pago_ISM" runat="server" TabIndex="9">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="Label8" runat="server" Text="Correo Electrónico" style="padding-left:40px;"></asp:Label>
                    </div>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtCorreo2" runat="server" TabIndex="10" Width="40%"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="Label9" runat="server" Text="Nombre para Constancia" style="padding-left:40px;"></asp:Label>
                    </div>
                    <div class="col-md-7">
                        <asp:TextBox ID="txtConstancia2" runat="server" Width="80%"></asp:TextBox>
                    </div>
                </div>
            </asp:Panel></td>
        </tr>

        <tr>
            <td>
                &nbsp;</td>
        </tr>

        <tr>
            <td>
                &nbsp;</td>
        </tr>

    </table>    
    
</asp:Content>
