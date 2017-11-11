<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="QuizFilosofando.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HiddenField ID="lblPerguntaId" runat="server" />
    <asp:HiddenField ID="lblPontuacao" runat="server" />
    <div id="page-wrapper">
        <div class="row">
            <div class="col-lg-12">
                <br />
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <asp:Label ID="lblPerguntaDescricao" runat="server"></asp:Label>
                    </div>
                    <div class="panel-body">
                        <asp:PlaceHolder runat="server" ID="mensagemErro" Visible="false">
                            <div class="alert alert-danger alert-dismissable">
                                <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>
                                <asp:Label ID="lblMensagem" runat="server"></asp:Label>
                            </div>
                        </asp:PlaceHolder>
                        <div class="row">
                            <div class="col-lg-12">
                                <form role="form">
                                    <fieldset>
                                        <div class="form-group">
                                            <div class="radio">
                                                <asp:RadioButtonList ID="rbRespostas" runat="server">
                                                    <asp:ListItem Text="text1" />
                                                    <asp:ListItem Text="text2" />
                                                    <asp:ListItem Text="text3" />
                                                    <asp:ListItem Text="text4" />
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                    </fieldset>
                                </form>
                            </div>
                            <div class="col-lg-12">
                                <asp:LinkButton ID="btnResponder" runat="server" class="btn btn-default btn-block"> <span class="glyphicon glyphicon-hand-right"></span>&nbsp;Responder</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>