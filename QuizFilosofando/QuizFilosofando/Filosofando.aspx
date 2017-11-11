<%@ Page Title="Filosofando" Language="C#" AutoEventWireup="true" CodeBehind="Filosofando.aspx.cs" Inherits="QuizFilosofando._Default" %>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta name="description" content="">
    <meta name="author" content="">
    <title>Filosofando</title>
    <!-- Bootstrap core CSS -->
    <link href="vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet">
    <!-- Custom fonts for this template -->
    <link href="vendor/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css">
    <link href="https://fonts.googleapis.com/css?family=Lora:400,700,400italic,700italic" rel="stylesheet" type="text/css">
    <link href='https://fonts.googleapis.com/css?family=Cabin:700' rel='stylesheet' type='text/css'>
    <link href="Content/Site.css" rel="stylesheet" />

    <!-- Custom styles for this template -->
    <link href="CSS/grayscale.min.css" rel="stylesheet">
    <link href="CSS/index.css" rel="stylesheet">
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
    <script src="Scripts/Script.js"></script>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>


</head>
<body id="page-top">
    <!-- Navigation -->
    <nav class="navbar navbar-expand-lg navbar-light fixed-top" id="mainNav">
        <div class="container">
            <a class="navbar-brand js-scroll-trigger" href="#page-top">filosofando</a>
            <button class="navbar-toggler navbar-toggler-right" type="button" data-toggle="collapse" data-target="#navbarResponsive" aria-controls="navbarResponsive" aria-expanded="false" aria-label="Toggle navigation">
                Menu
                <i class="fa fa-bars"></i>
            </button>
            <div class="collapse navbar-collapse" id="navbarResponsive">
                <ul class="navbar-nav ml-auto">
                    <li class="nav-item">
                        <a class="nav-link js-scroll-trigger" href="#about">Sobre</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link js-scroll-trigger" href="#download">O Jogo</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link js-scroll-trigger" href="#contact">Contato</a>
                    </li>
                </ul>
            </div>
        </div>
    </nav>
    <!-- Intro Header -->
    <header class="masthead">
        <div class="intro-body">
            <div class="container">
                <div class="row">
                    <div class="col-sm-auto col-lg-8 mx-auto">
                        </br>
                        </br>
                        </br>
                        <a href="#about" class="btn btn-circle js-scroll-trigger">
                            <i class="fa fa-angle-double-down animated"></i>
                        </a>
                    </div>
                </div>
            </div>
        </div>
    </header>
    <!-- About Section -->
    <section id="about" class="content-section content-section-about text-center">
        <div class="container">
            <div class="row">
                <div class="col-lg-8 mx-auto">
                    <h2>Sobre nós</h2>
                    
                    <p>
                        A equipe filosofando faz parte de um projeto chamado "Jovem e Tecnologia" que é disponibilizado pela META em parceria com a fundação Antônio Meneghetti.
                        Nosso objetivo é fazer com que as pessoas possam ter um material extra para que possam se divertir e, ao mesmo tempo, aprender mais sobre filosofia, de uma maneira prática.
                    </p>
                    
                    <figure>
                        <span class=" box trs next"></span>
                        <span class="box trs prev"></span>
                        <div class="col-sm-8 col-lg-6 mx-auto">
                            <div id="slider">
                                <a href="#" class="trs"><img style="width:100%; height:100%" src="Imagens/foto.jpg" alt="Lucas de Oliveira - Programador" /></a>
                                <a href="#" class="trs"><img style="width:100%; height:100%" src="Imagens/Renan.jpg" alt="Renan Pötter - Designer" /></a>
                                <a href="#" class="trs"><img style="width:100%; height:100%" src="Imagens/Vitória.jpg" alt="Vitória Ferreira - Analista de Banco de Dados" /></a>
                            </div>
                        </div>
                        <figcaption></figcaption>
                    </figure>
                </div>
            </div>
        </div>

    </section>
    <!-- Play Section -->
    <section id="download" class="download-section content-section text-center">
        <div class="container">
            <div class="col-lg-8 mx-auto">
                <h2>O Jogo</h2>
                <p>Divirta-se!</p>
                <a href="Dificuldades.aspx" class="btn btn-default btn-lg">Jogar!</a>
            </div>
        </div>
    </section>
    <!-- Contact Section -->
    <section id="contact" class="content-section content-section-contact text-center">
        <div class="container">
            <div class="row">
                <div class="col-lg-8 mx-auto">
                    <h2>Entre em contato conosco!</h2>
                    <p>Você pode ter mais informações pela nossa página no facebook, onde são disponibilizadas as novidades sobre o jogo, e também tirar suas dúvidas.</p>
                    <ul class="list-inline banner-social-buttons">
                        <li class="list-inline-item">
                            <a href="https://www.facebook.com/Filosofando-729888243887290/?ref=bookmarks" target="_blank" class="btn btn-default btn-lg">
                                <i class="fa fa-facebook fa-fw"></i>
                                <i class="network-name">FACEBOOK</i>
                            </a>
                        </li>
                        <li class="list-inline-item">
                            <a href="https://plus.google.com/+Startbootstrap/posts" class="btn btn-default btn-lg">
                                <i class="fa fa-envelope fa-fw"></i>
                                <i class="network-name">Email</i>
                            </a>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </section>

    <!-- Footer -->
    <footer>
        <div class="container text-center">
            <p>Copyright &copy; Jovem e Tecnologia-Filosofando 2017</p>
        </div>
    </footer>
    <!-- Bootstrap core JavaScript -->
    <script src="vendor/jquery/jquery.min.js"></script>
    <script src="vendor/popper/popper.min.js"></script>
    <script src="vendor/bootstrap/js/bootstrap.min.js"></script>
    <!-- Plugin JavaScript -->
    <script src="vendor/jquery-easing/jquery.easing.min.js"></script>
    <!-- Custom scripts for this template -->
    <script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyCRngKslUGJTlibkQ3FkfTxj3Xss1UlZDA&sensor=false"></script>
    <script src="js/grayscale.min.js"></script>

</body>
</html>
