<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pruebas.aspx.cs" Inherits="Recibos_Electronicos.Form.Pruebas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
                                <div class="row">
                                    <div class="col">
                                        <nav>
                    <div class="nav nav-tabs nav-fill" id="nav-tab" role="tablist">
                      <a class="nav-item nav-link active largefont" id="nav-home-tab" data-toggle="tab" href="#nav-home" role="tab" aria-controls="nav-home" aria-selected="true">
                          <i class="fa fa-eye" aria-hidden="true"></i> Monitor</a>
                      <a class="nav-item nav-link" id="nav-bancos-tab" data-toggle="tab" href="#nav-bancos" role="tab" aria-controls="nav-bancos" aria-selected="true">
                          <i class="fa fa-cloud-upload" aria-hidden="true"></i> Bancos cargados</a>
                    </div>
                  </nav>
                                        <div class="tab-content py-3 px-3 px-sm-0" id="nav-tabContent">
                                            <div class="tab-pane fade show active" id="nav-home" role="tabpanel" aria-labelledby="nav-home-tab">
                                                
                                            </div>
                                            <div class="tab-pane fade" id="nav-bancos" role="tabpanel" aria-labelledby="nav-bancos-tab">
                                                
                                            </div>
                                            
                                        </div>
                                    </div>
                                </div>
                            </div>



</asp:Content>
