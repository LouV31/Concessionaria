<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Concessionaria._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <div class="d-flex align-items-center">
            <asp:DropDownList ID="ddlExample" runat="server">
                <asp:ListItem Text="Seleziona il modello" />
            </asp:DropDownList>
            <asp:Button ID="sleziona" runat="server" OnClick="sleziona_Click" CssClass="ms-2 btn btn-success rounded-pill" Text="Seleziona" />
        </div>
        <div runat="server" class="d-flex flex-column border border-2 rounded-3 overflow-hidden">
            <asp:Image ID="immagine" runat="server" CssClass="w-100" />
            <p class="display-4 fw-normal" id="modello" runat="server"></p>
            <p class="fs-3 fw-bold" id="prezzo" runat="server"></p>
            <div class="d-flex align-items-center">
                <asp:Label CssClass="me-3" runat="server">Garanzia:</asp:Label>
                <asp:DropDownList runat="server" ID="garanzia">
                    <asp:ListItem Text="Seleziona anni di garanzia"></asp:ListItem>
                    <asp:ListItem Text="1" Value="1"></asp:ListItem>
                    <asp:ListItem Text="2" Value="2"></asp:ListItem>
                    <asp:ListItem Text="3" Value="3"></asp:ListItem>
                    <asp:ListItem Text="4" Value="4"></asp:ListItem>
                    <asp:ListItem Text="5" Value="5"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="d-flex flex-column">

                <div class="d-flex align-items-center">
                    <span class="me-2">Cerchi in lega</span>
                    <asp:CheckBox ID="cerchiInLega" runat="server" />
                </div>
                <div class="d-flex align-items-center">
                    <span class="me-2">Vernice</span>
                    <asp:CheckBox ID="vernice" runat="server" />
                </div>
                <div class="d-flex align-items-center">
                    <span class="me-2">Climatizzatore</span>
                    <asp:CheckBox ID="climatizzatore" runat="server" />
                </div>
                <div class="d-flex align-items-center">
                    <span class="me-2">Doppio air Bag</span>
                    <asp:CheckBox ID="airbag" runat="server" />
                </div>
                <div class="d-flex align-items-center">
                    <span class="me-2">ABS</span>
                    <asp:CheckBox ID="abs" runat="server" />
                </div>
                <asp:Button ID="prezzoFinale" runat="server" OnClick="prezzoFinale_Click" CssClass="ms-2 btn btn-success rounded-pill" Text="Calcola Prezzo" />
                <p runat="server" id="mostraPrezzoFinale" ></p>
            </div>
        </div>
</asp:Content>
