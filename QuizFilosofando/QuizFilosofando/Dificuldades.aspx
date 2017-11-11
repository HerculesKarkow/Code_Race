<%@ Page Title="Dificuldades"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dificuldades.aspx.cs" Inherits="QuizFilosofando.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <section id="contact" class="Niveis-section text-center">
        </br>
        </br>
        <div class="container">
            <div class="row">
                <div class="col-lg-8 mx-auto">
                    <div id="botoes" style="text-align: center">
                        <div style="margin-top: 20%; margin-bottom: 20%">
                            <h2> Selecione a Dificuldade</h2>
                            <asp:Button ID="btnFacil" CssClass="btn btn-default btn-lg" runat="server" Text="Fácil" OnClick="btnFacil_Click"  />
                            <asp:Button ID="btnMedio" CssClass="btn btn-default btn-lg" runat="server" Text="Médio" OnClick="btnMedio_Click" />
                            <asp:Button ID="btnDificil" CssClass="btn btn-default btn-lg" runat="server" Text="Difícil" />

                            <asp:Label  ID="lblRandom" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </section>
</asp:Content>
