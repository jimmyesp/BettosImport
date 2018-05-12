<%@ Page Title="" Language="C#" MasterPageFile="~/SiteIntranet.Master" AutoEventWireup="true" CodeBehind="EntradaProductos.aspx.cs" Inherits="BettosImport.Sigeinv.WebUI.INV.EntradaProductos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript">
        function Busqueda() {
           bettosimport.util.openModal('modalBusqueda', 'frameBusqueda', '<%=BettosImport.Sigeinv.Common.WebUtil.AbsoluteWebRoot%>Busqueda/Busqueda.aspx', 'Búsqueda de Productos');
        }

         function cargarDatosProducto(codigo, descripcion, marca, categoria, subcategoria) {
             $("#<%= hfCodProducto.ClientID %>").val(codigo);
             $("#<%= txtDescProducto.ClientID %>").val(descripcion);
             $("#<%= txtMarca.ClientID %>").val(marca);
             $("#<%= txtCategoria.ClientID %>").val(categoria);
             $("#<%= txtSubCategoria.ClientID %>").val(subcategoria);

             $("#modalBusqueda").dialog("close");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>            
            <div class="panel panel-primary">  
                 <div class="panel panel-heading clearfix">
                    <h4 class="panel-title pull-left" style="padding-top: 7.5px;">Entradas</h4>
                    <div class="pull-right">
                        <asp:LinkButton runat="server" ID="lbRegresar" CssClass="btn btn-success" OnClick="lbRegresar_Click">
                            <i class="glyphicon glyphicon-arrow-left" aria-hidden="true"></i> Retornar
                        </asp:LinkButton>
                        
                    </div>
                </div>  
                    
                <div class="panel panel-body">

                    <div class="row">
                        <div class="col-xs-4">
                            <label>Tipo de Entrada</label>
                              <asp:DropDownList ID="ddlTipoEntrada" AutoPostBack="true" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlTipoEntrada_SelectedIndexChanged"></asp:DropDownList> 
                        </div>
                        <div class="col-xs-4">
                            <label>Proveedor</label>
                              <asp:DropDownList ID="ddlProveedor" runat="server" CssClass="form-control" Enabled="false"></asp:DropDownList> 
                        </div>

                        <div class="col-xs-4">
                            <label>Tienda Origen</label>
                              <asp:DropDownList ID="ddlTiendaOrigen" runat="server" CssClass="form-control" Enabled="false"></asp:DropDownList> 
                        </div>
                    </div> 
                    <br />


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
                            <asp:TextBox ID="txtMarca" CssClass="form-control" runat="server" readonly="true" MaxLength="50"></asp:TextBox>                       
                       </div>
                       <div class="col-xs-4">
                            <label>Categoria</label>
                            <asp:TextBox ID="txtCategoria" CssClass="form-control" runat="server" readonly="true" MaxLength="50"></asp:TextBox>                       
                       </div>
                       <div class="col-xs-4">
                            <label>SubCategoria</label>
                            <asp:TextBox ID="txtSubCategoria" CssClass="form-control" runat="server" readonly="true" MaxLength="50"></asp:TextBox>                       
                        </div>
                    </div> 
                    <br />

                    <div class="row">
                        <div class="col-xs-4">
                            <label>Cantidad</label>
                            <asp:TextBox ID="txtCantidad" CssClass="form-control" placeholder="Cantidad" runat="server" readonly="false" MaxLength="50"></asp:TextBox>                       
                        </div>
                        <div class="col-xs-4">
                            <label>Tipo de Documento</label>
                              <asp:DropDownList ID="ddlTipoDocumento" runat="server" CssClass="form-control"></asp:DropDownList> 
                        </div>
                        <div class="col-xs-4">
                            <label>Nº Documento</label>
                            <asp:TextBox ID="txtNumDoc" CssClass="form-control" placeholder="Numero de Documento" runat="server" readonly="false" MaxLength="50"></asp:TextBox>                       
                        </div>
                    </div> 
                    <br />

                    <div class="row">      
                        <div class="col-xs-4">
                            <label>Fecha Emision</label>
                            <asp:TextBox ID="TxtFecEmision" textmode="Date" CssClass="form-control" runat="server"></asp:TextBox>                       
                        </div>     
                        <div class="col-xs-8">
                            <label>Comentario</label>
                            <asp:TextBox ID="txtComentario" textmode="MultiLine" CssClass="form-control" placeholder="Comentario" runat="server" readonly="false" MaxLength="500"></asp:TextBox>                       
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
