<%@ Page Title="" Language="C#" MasterPageFile="~/SiteIntranet.Master" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="BettosImport.Sigeinv.WebUI.ADM.Usuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(function () {

        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="panel panel-primary">
            
                <div class="panel panel-heading clearfix">
                    <h4 class="panel-title pull-left" style="padding-top: 7.5px;">Usuario</h4>
                    <div class="pull-right">
                        <asp:LinkButton runat="server" ID="lbRegresar" CssClass="btn btn-success" OnClick="lbRegresar_Click">
                            <i class="glyphicon glyphicon-arrow-left" aria-hidden="true"></i> Retornar
                        </asp:LinkButton>
                        
                    </div>
                </div>
                <div class="panel panel-body">
                    <div class="row">
                        <div class="col-xs-8">
                            <label>Descripción</label>
                            <asp:TextBox ID="txtDescripcion" CssClass="form-control" placeholder="Descripción" runat="server" readonly="false" MaxLength="100"></asp:TextBox>                       
                        </div>
                    </div>
                    <br />

                    <div class="row">
                        <div class="col-xs-8">
                            <label>Usuario</label>
                            <asp:TextBox ID="txtUsuario" CssClass="form-control" placeholder="Usuario" runat="server" readonly="false" MaxLength="10"></asp:TextBox>                       
                        </div>
                    </div>
                    <br />

                    <div class="row">
                        <div class="col-xs-8">
                            <label>Contraseña</label>
                            <asp:TextBox ID="txtPassword" CssClass="form-control" placeholder="Contraseña" runat="server" readonly="false" MaxLength="50"></asp:TextBox>                       
                        </div>
                    </div>

                    <br />
                  
                    <div class="row">
                        <div class="col-xs-4">
                            <label>Rol</label>
                              <asp:DropDownList ID="ddlRol" runat="server" CssClass="form-control"></asp:DropDownList> 
                        </div>
                    </div> 
                    <br />
                      <div class="row">
                         <div class="col-xs-2">
                            <label >Estado:</label>
                             <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-control">
                                <asp:ListItem>--Seleccione--</asp:ListItem>
                                <asp:ListItem Value="A">Activo</asp:ListItem>
                                <asp:ListItem Value="I">Inactivo</asp:ListItem>
                             </asp:DropDownList>   
                         </div>
                    </div> 
                    <div class="pull-right">
                        <asp:HiddenField ID="hfAccion" runat="server" />
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-info" Enabled="true" OnClick="btnGuardar_Click" />
                    </div>                             
                </div>           
            </div>  
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>

