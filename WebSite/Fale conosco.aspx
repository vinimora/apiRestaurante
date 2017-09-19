<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Fale conosco.aspx.cs" Inherits="Fale_conosco" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="StyleSheet.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Amatic+SC">
    <style>
        body, html {
            height: 100%;
        }

        body, h1, h2, h3, h4, h5, h6 {
            font-family: "Amatic SC", sans-serif;
        }
    </style>
   <br /><br /><br /><br /><br />
     <title>Fale Conosco </title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="fale-conosco" class="w3-container">
        <h1 class="w3-center w3-jumbo" style="margin-bottom:90px">Fale Conosco</h1>
        <form action="#" target="_blank">
          <p><input class="w3-input w3-padding-16 w3-border" type="text" placeholder="Seu Nome" required name="Nome"></p>
          <p><input class="w3-input w3-padding-16 w3-border" type="text" placeholder="Seu Email" required name="Email"></p>
          <p><input class="w3-input w3-padding-16 w3-border" type="text" placeholder="Escreva Sua Mensagem" required name="Mensagem"></p>
          <p><button class="w3-button w3-light-grey w3-block" type="submit">ENVIAR MENSAGEM</button></p>
        </form>
    </div>
</asp:Content>

