<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Exenciones.ascx.cs" Inherits="Recibos_Electronicos.ControlUsuario.Exenciones" %>
<style type="text/css">




.mGrid {  
    margin: 5px 0 5px 0;  
    font-family:Arial;
     border: solid 1px #D9D9D9; /* borde de al redededor del grid*/

     z-index:1;
 
}  

 * {
				margin:0px;
				padding:0px;
             
	}

    .mGrid tr {  
        padding: 4px 2px;  
        border: solid 0px #30ACEC; 
        font-size:9px;
    }  

        .mGrid .enc10px th {
            font-size:10px;
            text-transform:uppercase;
             text-shadow: white 0em 0.1em 0em;

background: rgba(239,239,239,1);
background: -moz-linear-gradient(top, rgba(239,239,239,1) 0%, rgba(199,199,199,1) 100%);
background: -webkit-gradient(left top, left bottom, color-stop(0%, rgba(239,239,239,1)), color-stop(100%, rgba(199,199,199,1)));
background: -webkit-linear-gradient(top, rgba(239,239,239,1) 0%, rgba(199,199,199,1) 100%);
background: -o-linear-gradient(top, rgba(239,239,239,1) 0%, rgba(199,199,199,1) 100%);
background: -ms-linear-gradient(top, rgba(239,239,239,1) 0%, rgba(199,199,199,1) 100%);
background: linear-gradient(to bottom, rgba(239,239,239,1) 0%, rgba(199,199,199,1) 100%);
filter: progid:DXImageTransform.Microsoft.gradient( startColorstr='#efefef', endColorstr='#c7c7c7', GradientType=0 );
        }
    
       .mGrid10px td {  
              font-size:10px;
    } 

           .mGrid td {  
     padding: 2px;  
     border: solid 0px; 
        color: #1A1A1A;  /*color texto td */
           font-size:11px;
         text-transform:uppercase;
    }  
  
     .mGrid .alt {  
      background:#F2F2F2; /*  td alternado */
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
  
        
    
    
    .mGrid .enc tr span{
  
       color:#424242;
        font-size:15px;
        text-shadow: white 0em 0.1em 0em;
  
    } 
  
    
    .mGrid a{
      color:#0098CB;
    text-decoration:none;
}
  
    a{
    color:#0098CB;
    text-decoration:none;
}

</style>
                                                            <asp:GridView ID="grvAlumnos" runat="server" AllowPaging="True" AutoGenerateColumns="False" CssClass="mGrid mGrid10px" EmptyDataText="No se encontro ningún registro" GridLines="None" OnPageIndexChanging="grvAlumnos_PageIndexChanging" OnSelectedIndexChanged="grvAlumnos_SelectedIndexChanged" PageSize="12" Width="100%">
                                                                <Columns>
                                                                    <asp:BoundField DataField="IdPersona" HeaderText="id" />
                                                                    <asp:BoundField DataField="GenerarPermiso" SortExpression="GenerarPermiso" />
                                                                    <asp:BoundField DataField="Dependencia" HeaderText="Dep." />
                                                                    <asp:BoundField DataField="ConceptoDescuento" HeaderText="ConceptoDescuento" />
                                                                    <asp:BoundField DataField="Matricula" HeaderText="Matric">
                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Nombre" HeaderText="Nombre">
                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                    </asp:BoundField>
                                                                    <asp:TemplateField HeaderText="Ciclo">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblDetalle" runat="server" ToolTip='<%# Bind("Observaciones") %>' Text='<%# Bind("CicloEscolar") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:BoundField DataField="TipoDescuento" HeaderText="Tipo Descuento" ItemStyle-HorizontalAlign="Center">
                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="StatusMatricula" HeaderText="Status">
                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Referencia" HeaderText="Referencia">
                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                    <ItemStyle HorizontalAlign="Left" />
                                                                    </asp:BoundField>
                                                                    <asp:BoundField DataField="Nivel" />
                                                                </Columns>
                                                                <FooterStyle CssClass="enc" />
                                                                <PagerStyle CssClass="enc" HorizontalAlign="Center" />
                                                                <SelectedRowStyle CssClass="sel" />
                                                                <HeaderStyle CssClass="enc10px" />
                                                                <AlternatingRowStyle CssClass="alt" />
                                                            </asp:GridView>
                                                        
