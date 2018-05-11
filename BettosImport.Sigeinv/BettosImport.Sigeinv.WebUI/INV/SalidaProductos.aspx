<%@ Page Title="" Language="C#" MasterPageFile="~/SiteIntranet.Master" AutoEventWireup="true" CodeBehind="SalidaProductos.aspx.cs" Inherits="BettosImport.Sigeinv.WebUI.INV.SalidaProductos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function Busqueda() {
           bettosimport.util.openModal('modalBusqueda', 'frameBusqueda', '<%=BettosImport.Sigeinv.Common.WebUtil.AbsoluteWebRoot%>Busqueda/Busqueda.aspx', 'Búsqueda de Productos');
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>            
            <div class="panel panel-primary">
                <div class="panel panel-heading clearfix">
                    <h4 class="panel-title pull-left" style="padding-top: 7.5px;">Salidas</h4>
                    <div class="pull-right">
                        <asp:LinkButton runat="server" ID="lbRegresar" CssClass="btn btn-success" OnClick="lbRegresar_Click">
                            <i class="glyphicon glyphicon-arrow-left" aria-hidden="true"></i> Retornar
                        </asp:LinkButton>
                        
                    </div>
                </div>  
                <div class="panel panel-body">
              

                    <div class="row">
                        <div class="col-xs-4">
                            <label>Producto</label>
                            <div class="input-group"> 
                               
                               <asp:HiddenField ID="hfCodProducto" runat="server" />
                               <asp:TextBox ID="txtDescProducto" CssClass="form-control" placeholder="Descripcion Producto" runat="server" readonly="true" MaxLength="50"></asp:TextBox>
                                <span class="input-group-btn">
                                  <asp:Button ID="btnBuscarProducto" runat="server" Text="Buscar" CssClass="btn btn-info" Enabled="true" OnClientClick="javascript:  $(function () { Busqueda(); });"/>  
                               </span>      
                            </div>
                                            
                        </div>
                    </div> 
                    <br />

                    <div class="row">
                       <div class="col-xs-4">
                            <label>Marca</label>
                            <asp:TextBox ID="txtMarca" CssClass="form-control" placeholder="Marca" runat="server" readonly="true" MaxLength="50"></asp:TextBox>                       
                       </div>
                       <div class="col-xs-4">
                            <label>Categoria</label>
                            <asp:TextBox ID="txtCategoria" CssClass="form-control" placeholder="Categoria" runat="server" readonly="true" MaxLength="50"></asp:TextBox>                       
                       </div>
                       <div class="col-xs-4">
                            <label>SubCategoria</label>
                            <asp:TextBox ID="txtSubCategoria" CssClass="form-control" placeholder="SubCategoria" runat="server" readonly="true" MaxLength="50"></asp:TextBox>                       
                        </div>
                    </div> 
                    <br />

                    <div class="row">
                        <div class="col-xs-4">
                            <label>Tienda Destino</label>
                              <asp:DropDownList ID="ddlTiendaDestino" runat="server" CssClass="form-control"></asp:DropDownList> 
                        </div>
                        <div class="col-xs-4">
                            <label>Cantidad</label>
                            <asp:TextBox ID="txtCantidad" CssClass="form-control" placeholder="Cantidad" runat="server" readonly="false" MaxLength="50"></asp:TextBox>                       
                        </div>
                        <div class="col-xs-4">
                            <label>Tipo de Documento</label>
                              <asp:DropDownList ID="ddlTipoDocumento" runat="server" CssClass="form-control"></asp:DropDownList> 
                        </div>
                    </div> 
                    <br />

                  
                    <div class="row">           
                         <div class="col-xs-4">
                            <label>Nº Documento</label>
                            <asp:TextBox ID="txtNumDoc" CssClass="form-control" placeholder="Numero de Documento" runat="server" readonly="false" MaxLength="50"></asp:TextBox>                       
                        </div>
                        <div class="col-xs-8">
                            <label>Comentario</label>
                            <asp:TextBox ID="txtComentario" TextMode="MultiLine" CssClass="form-control" placeholder="Comentario" runat="server" readonly="false" MaxLength="500"></asp:TextBox>                       
                        </div>
                    </div> 
                    <br />
                    <br />

                    <div class="pull-right">
                        <asp:HiddenField ID="hfAccion" runat="server" />
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-info" Enabled="true"/>
                    </div>                            
                </div>           
            </div>
            
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
