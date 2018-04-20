
<!DOCTYPE html>
<!--[if lt IE 7]>      <html class="no-js lt-ie9 lt-ie8 lt-ie7"> <![endif]-->
<!--[if IE 7]>         <html class="no-js lt-ie9 lt-ie8"> <![endif]-->
<!--[if IE 8]>         <html class="no-js lt-ie9"> <![endif]-->
<!--[if gt IE 8]><!--> <html class="no-js"> <!--<![endif]-->
		<meta charset="utf-8">
	<meta http-equiv="X-UA-Compatible" content="IE=edge">
	<title>Imóveis e Despachante</title>
	<meta name="viewport" content="width=device-width, initial-scale=1">
	<meta name="description" content="Corretor de imóveis e Despachante Miguel Pereira" />
	<meta name="keywords" content="Imóveis,imoveis,Miguel Pereira, Corretor de imoveis,Despachante,Imóveis em Miguel Pereira,Rosane Monteiro,Marcus Brito, Legalização de Documentos, Inventário, Comprar imóveis em Miguel Pereira, Imóveis baratos">
	<meta name="author" content="Nathan Vieira" />



  	<!-- Facebook and Twitter integration -->
	<meta property="og:title" content=""/>
	<meta property="og:image" content=""/>
	<meta property="og:url" content=""/>
	<meta property="og:site_name" content=""/>
	<meta property="og:description" content=""/>
	<meta name="twitter:title" content="" />
	<meta name="twitter:image" content="" />
	<meta name="twitter:url" content="" />
	<meta name="twitter:card" content="" />

	<!-- Place favicon.ico and apple-touch-icon.png in the root directory -->
	<link rel="shortcut icon" href="favicon.ico">
	<link href='https://fonts.googleapis.com/css?family=Varela+Round' rel='stylesheet' type='text/css'>
	<!-- <link href='https://fonts.googleapis.com/css?family=Open+Sans:400,300,600,400italic,700' rel='stylesheet' type='text/css'> -->
	
	<!-- Animate.css -->
	<link rel="stylesheet" href="css/animate.css">
	<!-- Icomoon Icon Fonts-->
	<link rel="stylesheet" href="css/icomoon.css">
	<!-- Bootstrap  -->
	<link rel="stylesheet" href="css/bootstrap.css">
	<!-- Flexslider  -->
	<link rel="stylesheet" href="css/flexslider.css">
	<!-- Theme style  -->
	<link rel="stylesheet" href="css/style.css">

	<!-- Modernizr JS -->
	<script src="js/modernizr-2.6.2.min.js"></script>
	<!-- FOR IE9 below -->
	<!--[if lt IE 9]>
	<script src="js/respond.min.js"></script>
	<![endif]-->

	</head>
	<body id = "body">
	
	
	<div id="fh5co-page">
	<header id="fh5co-header" role="banner">
		<div class="container">
			<div class="row">
				
				<div class="header-inner">
					<h1><a href="index.php">Imóveis e Despachante <span>.</span></a></h1>
							<nav role="navigation">

						<ul>
							<li><a href="docs.html">Legalização</a></li>
							<li><a href="properties.php">Imóveis</a></li>							
							<li class="call"><a href="tel://5524981246123"><i class="icon-phone"></i> (24) 98124-6123 </a><i class="icon-whatsapp"></i></li>
							<li class="cta"><a href="contact.html">Contato</a></li>
						</ul>
					</nav>
				</div>
			</div>
		</div>
	</header>

	<?php

	$servername = "localhost";
    $username = "u938492100_natha";
    $pass = "24842288";
    $dbname ="u938492100_imvs";
    $connect = new mysqli($servername,$username,$pass,$dbname);
    mysqli_set_charset($connect,"utf8") or die(mysqli_error($connect));
    $sql2 = "SELECT  `id` AS id,  `titulo` AS title,  `preço` AS price,  `negocio` AS neg,  `dpeq` AS dpeq, 
    		 `taman` AS taman,  `imgs` AS img
			FROM  `imoveis` 			
			WHERE 1
			ORDER BY RAND() ";
    $result = mysqli_query($connect, $sql2) or die(mysqli_error($conn));
    $imvs="";
	     if(mysqli_num_rows($result) > 0)
		{
			while($row = mysqli_fetch_assoc($result))
			{

				$imvs= $imvs. $row['id']."|".$row['title']."|".$row['price']."|".$row['neg']."|".$row['dpeq']."|".
				$row['taman']."|".$row['img']."ª";
			}
		}

		
	?>

	<aside id="fh5co-hero" clsas="js-fullheight">
	
		<div class="flexslider js-fullheight" id = "roler">
			<ul class="slides" id ="mainslide">		  
		   
		   	
		  	</ul>
	  	</div>
	</aside>
	<script>
	var data = `<?php echo $imvs;?>`;
	var imvs = data.split("ª");	

	function createMainSlider(info){	
	var infs = info.split("|");
	var sell = infs[3]=="0"?"À venda":"Alugar";
	var img = infs[6].split("º")[0];
	var value = (parseInt(infs[2])).toLocaleString('pt-BR', { style: 'currency', currency: 'BRL' });
	var a = " <li style='background-image: url("+img+");'> <div class='container'> <div class='col-md-12 text-center js-fullheight fh5co-property-brief slider-text'> <div class='fh5co-property-brief-inner'> <div class='fh5co-box'> <h3><a href='info.php?id="+infs[0]+"''>"+infs[1]+"</a></h3> <div class='price-status'> <span class='price'>"+value+" <a href='#' class='tag'>"+sell+"</a></span> </div> <p>"+infs[4]+"</p> <p class='fh5co-property-specification'> <span><strong>"+infs[5]+"</strong> m²</span> </p> <p><a href='info.php?id="+infs[0]+"' class='btn btn-primary'>Saiba Mais</a></p> </div> </div> </div> </div> </li>";
	document.getElementById("mainslide").innerHTML += a;
}
	createMainSlider(imvs[0]);
	createMainSlider(imvs[1]);
	createMainSlider(imvs[2]);
	</script>
	
	<div id="best-deal">
		<div class="container">
			<div class="row" id= "bestrow">
				<div class="col-md-8 col-md-offset-2 text-center fh5co-heading animate-box " data-animate-effect="fadeIn">
					<h2>As melhores opções para sua família no 3º melhor clima do mundo</h2>
					<p>Uma oportunidade única </p>
						<a href='properties.php' class='btn btn-primary btn-outline with-arrow'>Todos Imóveis <i class='icon-arrow-right'></i></a>
				</div>			


			</div>
		</div>
	</div>
<script>
	

	function createPropiete(info){
		var infs = info.split("|");
		var sell = infs[3]=="0"?"À venda":"Alugar";
		var img = infs[6].split("º")[0];
		var value = (parseInt(infs[2])).toLocaleString('pt-BR', { style: 'currency', currency: 'BRL' });

	var b = "<div class='col-md-4 item-block animate-box' data-animate-effect='fadeIn'> <div class='fh5co-property'><figure><a href='info.php?id="+infs[0]+"'><img src='"+img+"' alt='' class='img-responsive'></a> <a href='info.php?id="+infs[0]+"' class='tag'>"+sell+"</a> </figure> <div class='fh5co-property-innter'> <h3><a href='info.php?id="+infs[0]+"'>"+infs[1]+"</a></h3> <div class='price-status'> <span class='price'>"+value+" </span> </div> <p>"+infs[4]+"</p> </div> <p class='fh5co-property-specification'> <span><strong>"+infs[5]+"</strong> m²</span>  </p> </div> </div>   ";
	document.getElementById("bestrow").innerHTML += b;
	}
	if (imvs[3]!=null)createPropiete(imvs[3]);
	if (imvs[4]!=null)createPropiete(imvs[4]);
	if (imvs[5]!=null)createPropiete(imvs[5]);

	

	</script>

	<div class="fh5co-section-with-image">
		
		<img src="images/bimoveis.png" alt="" class="img-responsive">
		<div class="fh5co-box animate-box  ">
			<h2>Segurança, Conforto &amp; Confiança </h2>
			<p>Buscamos proporcionar ao cliente facilidade e comodidade, legalizando seu imóvel perante os órgãos reguladores e proporcionando as melhores ofertas do mercado.</p>
			<p><a href="docs.html" class="btn btn-primary btn-outline with-arrow">Começar <i class="icon-arrow-right"></i></a></p>
		</div>
		
	</div>
	

	

	<div id="fh5co-agents">
		<div class="container">
			<div class="row">
				<div class="col-md-6 col-md-offset-3 text-center fh5co-heading white animate-box" data-animate-effect="fadeIn">
					<h2>Nossa equipe</h2>
					
				</div>
				<div class="col-md-6  text-center item-block animate-box" data-animate-effect="fadeIn">
					<div class="fh5co-agent">
						<figure>
							<img src="imgs/marcus.jpg" alt="">
						</figure>
						<h3>Marcus Brito</h3>
						<h5>CRECI 58898-RJ <br>INSCR.MUNICIPAL. 02-5285</h5>
						
						<p>(24) 98109-0066</p>
						<p><a href="tel://5524981090066" class="btn btn-primary btn-outline">Ligar</a></p>
					</div>
				</div>
				
				<div class="col-md-6  text-center item-block animate-box" data-animate-effect="fadeIn">

					<div class="fh5co-agent">
						<figure>
							<img src="imgs/rosane.jpg" >
						</figure>
						<h3>Rosane Monteiro</h3>
						<h5>CRECI 58990-RJ <br> &nbsp;	</h5>
						
						<p>(24) 98124-6123</p>
						<p><a href="tel://5524981246123" class="btn btn-primary btn-outline">Ligar</a></p>
					</div>
					
				</div>
				
			</div>
		</div>
	</div>
	

	

	
	<footer id="fh5co-footer" role="contentinfo">
	
		<div class="container">
			<div class="col-md-8 col-sm-12 col-sm-push-0 col-xs-12 col-xs-push-0">
				<h3>Sobre nós</h3>
			<p> Marcus e Rosane somam mais de 40 anos de experiência em cartórios de registros de imóveis, oferecendo as soluções mais eficientes e viáveis para a legalização do seu imóvel.
 </p>				
			</div>
			

			<div class="col-md-2 col-md-push-1 col-sm-12 col-sm-push-0 col-xs-12 col-xs-push-0">
<h3>Redes socias</h3>
				<ul class="fh5co-social">					
					<li><a  target="_blank" href="https://www.facebook.com/Corretores-de-Im%C3%B3veis-Despachante-Municipal-Miguel-Pereira-334616163340259/"><i class="icon-facebook"></i></a></li>
					<li><a  target="_blank" href="mailto:rjmimoveismp@gmail.com"><i class="icon-google-plus"></i></a></li>					
				</ul>
			</div>
			
			
			<div class="col-md-12 fh5co-copyright text-center">
				<p><p>&copy; 2018 All Rights Reserved.<span>Desenvolvido por Nathan Vieira de Magalhães <span><a target="_blank" href="https://nathanvmag.github.io"<p>Website </p></a> </p>	
					
			</div>
			
		</div>
	</footer>
	</div>
	
	
	
	<!-- jQuery -->
	<script src="js/jquery.min.js"></script>
	<!-- jQuery Easing -->
	<script src="js/jquery.easing.1.3.js"></script>
	<!-- Bootstrap -->
	<script src="js/bootstrap.min.js"></script>
	<!-- Waypoints -->
	<script src="js/jquery.waypoints.min.js"></script>
	<!-- Flexslider -->
	<script src="js/jquery.flexslider-min.js"></script>

	<!-- MAIN JS -->
	<script src="js/main.js"></script>

	</body>
</html>

