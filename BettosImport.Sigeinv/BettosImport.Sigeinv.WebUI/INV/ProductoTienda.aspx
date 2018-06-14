<%@ Page Title="" Language="C#" MasterPageFile="~/SiteIntranet.Master" AutoEventWireup="true" CodeBehind="ProductoTienda.aspx.cs" Inherits="BettosImport.Sigeinv.WebUI.INV.ProductoTienda" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
       <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
           
            <div class="panel panel-primary">
                <div class="panel panel-heading clearfix">
                    <h4 class="panel-title pull-left" style="padding-top: 7.5px;">Producto - Tienda</h4>
                    <div class="pull-right">
                        <asp:LinkButton runat="server" ID="lbRegresar" CssClass="btn btn-success" OnClick="lbRegresar_Click">
                            <i class="glyphicon glyphicon-arrow-left" aria-hidden="true"></i> Retornar
                        </asp:LinkButton>
                        
                    </div>
                </div>
                <div class="panel panel-body">
                    <div class="row">
                        <div class="col-xs-4">
                            <label>Tienda</label>
                            <asp:TextBox ID="txtTienda" CssClass="form-control" runat="server" readonly="false" MaxLength="100" Enabled="false"></asp:TextBox>                        
                        </div>

                        <div class="col-xs-4">
                            <label>Producto</label>
                             <asp:DropDownList ID="ddlProducto" runat="server" CssClass="form-control"></asp:DropDownList>

                        </div>
                        <div class="col-xs-4">
                            <label>Cantidad</label>
                            <asp:TextBox ID="txtCantidad" CssClass="form-control" placeholder="Descripción" runat="server" readonly="false" MaxLength="100"></asp:TextBox>                        
                        </div>
                    </div>
                    <br />

                    <div class="pull-right">
                        <asp:HiddenField ID="hfAccion" runat="server" />
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-info" Enabled="true" OnClick="btnGuardar_Click"/>
                    </div>                              
                </div>           
            </div>  
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
