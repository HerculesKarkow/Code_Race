<%@ Page Title="Perguntas-Fácil" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Perguntas.aspx.cs" Inherits="QuizFilosofando.Perguntas" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <section id="contact" class="Niveis-section">
        <asp:HiddenField ID="lblIdPergunta" runat="server" />
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
                            <asp:Label ID="lblPergunta" runat="server"></asp:Label>
                        </div>
                        <div class="row">
                            <div class="col-lg-4">
                                <form role="form">
                                    <fieldset style="color: black">
                                        <div class="form-group">
                                            <div class="radio">
                                                <asp:RadioButtonList runat="server" ID="rbRespostas" Style="color: Black">
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
                                <asp:Button runat="server" ID="btnEnviarResposta" CssClass="btn btn-default btn-lg" Text="Enviar Resposta" OnClick="btnEnviarResposta_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </section>
</asp:Content>
