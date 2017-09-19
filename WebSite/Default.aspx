<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        <link href="StyleSheet.css" rel="stylesheet" />
    <title>Home</title>
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Amatic+SC">
    <style>
        body, html {
            height: 100%;
        }

        body, h1, h2, h3, h4, h5, h6 {
            font-family: "Amatic SC", sans-serif;
        }

        .menu {
            display: none;
        }

        .bgimg {
            background-repeat: no-repeat;
            background-size: cover;
            background-image: url(imagens/sushi.jpg);
            min-height: 90%; background-repeat:no-repeat; background-size:100% 200%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1 id="logo-banner">TABALATO</h1>
   <div class="bgimg w3-display-container w3-grayscale-min">
  <div class="w3-display-bottomleft w3-padding">
    
  </div>
  <div class="w3-display-middle w3-center">
    <span class="w3-text-white w3-hide-small" style="font-size:100px">thin<br />Tabalato</span>
    <span class="w3-text-white w3-hide-large w3-hide-medium" style="font-size:60px; position:relative;"><b>thin<br />Tabalato</b></span>
            
         <img src="imagens/sushi.jpg" style="width:1500px; height:1200px " />
      <h2 id="logo-localizacao">Encontre-nos</h2>
      <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d457.2589766179476!2d-46.7926133882524!3d-23.529919384698534!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x94ceffac6b4e3953%3A0x5c1357c5581b1850!2sAv.+Ol%C3%A1vo+Bilac%2C+47+-+Km+18%2C+Osasco+-+SP%2C+06190-150!5e0!3m2!1spt-BR!2sbr!4v1499257711037" width="600" height="450" frameborder="0" style="border:0" allowfullscreen></iframe>
  
   
  </div>
       </div>
   
</asp:Content>

