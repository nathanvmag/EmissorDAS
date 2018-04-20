
<!DOCTYPE html>
<!--[if lt IE 7]>      <html class="no-js lt-ie9 lt-ie8 lt-ie7"> <![endif]-->
<!--[if IE 7]>         <html class="no-js lt-ie9 lt-ie8"> <![endif]-->
<!--[if IE 8]>         <html class="no-js lt-ie9"> <![endif]-->
<!--[if gt IE 8]><!--> <html class="no-js"> <!--<![endif]-->
			<meta charset="utf-8">
	<meta http-equiv="X-UA-Compatible" content="IE=edge">
	<title>EMITIR DAS - ADMIN</title>
	<meta name="viewport" content="width=device-width, initial-scale=1">
	<meta name="description" content="" />
	<meta name="keywords" content="">
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
	<!-- jQuery -->
	<script src="js/jquery.min.js"></script>
	<script src="js/md5.js?1"></script>
	<!-- jQuery Easing -->
	<script src="js/jquery.easing.1.3.js"></script>
	<!-- Bootstrap -->
	<script src="js/bootstrap.min.js"></script>
	<!-- Waypoints -->
	<script src="js/jquery.waypoints.min.js"></script>
	<!-- Flexslider -->
	<script src="js/jquery.flexslider-min.js"></script>
	<!-- Google Map -->
	
<script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-maskmoney/3.0.2/jquery.maskMoney.min.js" type="text/javascript"></script>
	
	<!-- MAIN JS -->
	<script src="js/main.js"></script>

	</head>
	<body id = "body">
	<?php header("Access-Control-Allow-Origin: *");
		header("Access-Control-Allow-Headers: Content-Type"); 
		
		
		
		?>
	<!-- <?php
	/*
	set_time_limit(0);


	$servername = "localhost";
    $username = "u938492100_natha";
    $pass = "24842288";
    $dbname ="u938492100_imvs";
    
    $connect = new mysqli($servername,$username,$pass,$dbname);
    mysqli_set_charset($connect,"utf8") or die(mysqli_error($connect));
    $sql2 = "";
    $result = mysqli_query($connect, $sql2) or die(mysqli_error($conn));    
	     if(mysqli_num_rows($result) > 0)
		{
			while($row = mysqli_fetch_assoc($result))
			{

				
			}
		}
		
	
		
		
	*/
		
	?>
-->
	
	<div id="fh5co-page">
	<header id="fh5co-header" role="banner">
		<div class="container">
			<div class="row">
				<div class="header-inner">
					<h1><a href="index.php">Emissor DAS <span>.</span></a></h1>
					<nav role="navigation">
						<ul>
							<li><a href="">Início</a></li>
							<li><a href="">Serviços</a></li>							
							
						</ul>
					</nav>
				</div>
			</div>
		</div>
	</header>


	<div id="best-deal">
		<div class="container">
			<div class="row" id= "bestrow">

				<div class="col-md-8 col-md-offset-2 text-center fh5co-heading animate-box" data-animate-effect="fadeIn">
					<h2>Digite a senha de Administrador</h2>
					
				</div>			


			
			<div class="col-md-8 col-md-push-4 col-sm-12 col-sm-push-0 col-xs-12 col-xs-push-0" data-animate-effect="fadeIn">
					<div class="row">
						<div class="col-md-6">
							<div class="form-group">
								<input id="pass" class="form-control" placeholder="Senha" type="password" Value="" name="senha">
							</div>
						</div>						
					</div>
				</div>
				<div class="col-md-8 col-md-push-5 col-sm-12 col-sm-push-0 col-xs-12 col-xs-push-0" data-animate-effect="fadeIn">
							<div class="form-group">
								<input id="pass1" value="Entrar" class="btn btn-primary" type="submit" onclick="EntrarButton()">
							</div>
						
			</div>					
	</div>

		</div>
	</div>

	<script type="text/javascript">
		var tabsvalues =["Sem substituição tributária/tributação monofásica/antecipação com encerramento de tributação (o substituto tributário do ICMS deve utilizar essa opção)","Com substituição tributária/tributação monofásica/antecipação com encerramento de tributação (o substituído tributário do ICMS deve utilizar essa opção)","Revenda de mercadorias para o exterior","Sem substituição tributária/tributação monofásica/antecipação com encerramento de tributação (o substituto tributário do ICMS deve utilizar essa opção)","Com substituição tributária/tributação monofásica/antecipação com encerramento de tributação (o substituído tributário do ICMS deve utilizar essa opção)","Venda de mercadorias industrializadas pelo contribuinte para o exterior","Locação de bens móveis, exceto para o exterior","Locação de bens móveis para o exterior","Escritórios de serviços contábeis autorizados pela legislação municipal a pagar o ISS em valor fixo em guia do Município","Sujeitos ao fator “r”, sem retenção/substituição tributária de ISS, com ISS devido a outro(s) Município(s)","Sujeitos ao fator “r”, sem retenção/substituição tributária de ISS, com ISS devido ao próprio Município do estabelecimento","Sujeitos ao fator “r”, com retenção/substituição tributária de ISS","Não sujeitos ao fator “r” e tributados pelo Anexo III, sem retenção/substituição tributária de ISS, com ISS devido a outro(s) Município(s)","Não sujeitos ao fator “r” e tributados pelo Anexo III, sem retenção/substituição tributária de ISS, com ISS devido ao próprio Município do estabelecimento","Não sujeitos ao fator “r” e tributados pelo Anexo III, com retenção/substituição tributária de ISS","Sujeitos ao Anexo IV, sem retenção/substituição tributária de ISS, com ISS devido a outro(s) Município(s)","Sujeitos ao Anexo IV, sem retenção/substituição tributária de ISS, com ISS devido ao próprio Município do estabelecimento","Sujeitos ao Anexo IV, com retenção/substituição tributária de ISS","Serviços da área da construção civil relacionados nos subitens 7.02 e 7.05 da lista anexa à LC 116/2003 e tributados pelo Anexo III, sem retenção/substituição tributária de ISS, com ISS devido a outro(s) Município(s)","Serviços da área da construção civil relacionados nos subitens 7.02 e 7.05 da lista anexa à LC 116/2003 e tributados pelo Anexo III, sem retenção/substituição tributária de ISS, com ISS devido ao próprio Município do estabelecimento","Serviços da área da construção civil relacionados nos subitens 7.02 e 7.05 da lista anexa à LC 116/2003 e tributados pelo Anexo III, com retenção/substituição tributária de ISS","Serviços da área da construção civil relacionados nos subitens 7.02 e 7.05 da lista anexa à LC 116/2003 e tributados pelo Anexo IV, sem retenção/substituição tributária de ISS, com ISS devido a outro(s) Município(s)","Serviços da área da construção civil relacionados nos subitens 7.02 e 7.05 da lista anexa à LC 116/2003 e tributados pelo Anexo IV, sem retenção/substituição tributária de ISS, com ISS devido ao próprio Município do estabelecimento","Serviços da área da construção civil relacionados nos subitens 7.02 e 7.05 da lista anexa à LC 116/2003 e tributados pelo Anexo IV, com retenção/substituição tributária de ISS","Serviços de transporte coletivo municipal rodoviário, metroviário, ferroviário e aquaviário de passageiros, sem retenção/substituição tributária de ISS, com ISS devido a outro(s) Município(s)","Serviços de transporte coletivo municipal rodoviário, metroviário, ferroviário e aquaviário de passageiros, sem retenção/substituição tributária de ISS, com ISS devido ao próprio Município do estabelecimento","Serviços de transporte coletivo municipal rodoviário, metroviário, ferroviário e aquaviário de passageiros, com retenção/substituição tributária de ISS","Escritórios de serviços contábeis autorizados pela legislação municipal a pagar o ISS em valor fixo em guia do Município","Sujeitos ao fator “r”","Não sujeitos ao fator “r” e tributados pelo Anexo III","Sujeitos ao Anexo IV","Serviços da área da construção civil relacionados nos subitens 7.02 e 7.05 da lista anexa à LC 116/2003 e tributados pelo Anexo III","Serviços da área da construção civil relacionados nos subitens 7.02 e 7.05 da lista anexa à LC 116/2003 e tributados pelo Anexo IV","Transporte sem substituição tributária de ICMS (o substituto tributário deve utilizar essa opção)","Transporte com substituição tributária de ICMS (o substituído tributário deve utilizar essa opção)","Comunicação sem substituição tributária de ICMS (o substituto tributário deve utilizar essa opção)","Comunicação com substituição tributária de ICMS (o substituído tributário deve utilizar essa opção)","Transporte","Comunicação","Sem retenção/substituição tributária de ISS, com ISS devido a outro(s) Município(s)","Sem retenção/substituição tributária de ISS, com ISS devido ao próprio Município do estabelecimento","Com retenção/substituição tributária de ISS","Atividades com incidência simultânea de IPI e de ISS para o exterior"];
			


		function ShowHouses(info){
			var infs = info.split("|");
			var value = (parseInt(infs[2])).toLocaleString('pt-BR', { style: 'currency', currency: 'BRL' });
			var b = "<div class='col-md-10 col-md-push-2 col-sm-12 col-sm-push-0 col-xs-12 col-xs-push-0' data-animate-effect='fadeIn'> <div class='form-group' > <h3> <i class ='icon-home'> </i> "+infs[1]+" &nbsp;&nbsp;&nbsp;<i class='icon-money'> </i> "+value+"&nbsp;&nbsp;&nbsp; <button class='btn btn-primary btn-outline' onclick='edit("+infs[0]+")' > Editar</button> <button class='btn btn-primary btn-outline' onclick='exclui("+infs[0]+")' >Excluir </button></span> </h3> </div> </div></div>";
			document.getElementById("bestrow").innerHTML += b;
		}
		var cnpjj;
			function getCNPJinf(cnpj)
			{
				cnpjj= cnpj;
				if (cnpj.length==14)
				{
					
					var url= "https://www.receitaws.com.br/v1/cnpj/"+cnpj;
					$.post('cnpj.php', { url: url }, function(data) {
					   var obj = JSON.parse(data);
					   if (obj.status=="OK")
					   {
					   	console.log("DKJKJ");

					   	 var values = [ "tipo","abertura","nome","fantasia","natureza_juridica",
                        "logradouro","numero","complemento","cep","bairro","municipio","uf","email","telefone",
                    "efr","situacao","data_situacao","motivo_situacao","situacao_especial","data_situacao_especial"];

                    	 var resumes = [ "TIPO:", "DATA DE ABERTURA:","NOME EMPRESARIAL:",
                    "TÍTULO DO ESTABELECIMENTO (NOME DE FANTASIA):","CÓDIGO E DESCRIÇÃO DA NATUREZA JURÍDICA:","LOGRADOURO:","NÚMERO:","COMPLEMENTO:","CEP:",
                    "BAIRRO/DISTRITO:","MUNICÍPIO:","UF:","ENDEREÇO ELETRÔNICO:","TELEFONE:","ENTE FEDERATIVO RESPONSÁVEL (EFR):","SITUAÇÃO CADASTRAL:",
                    "DATA DA SITUAÇÃO CADASTRAL:","MOTIVO DE SITUAÇÃO CADASTRAL:","SITUAÇÃO ESPECIAL:","DATA DA SITUAÇÃO ESPECIAL:" ];
                    		document.getElementById("ola").innerHTML="";
                    		for(var i=0;i<values.length;i++){
                    			var resp= obj[values[i]]!=""?obj[values[i]]:"---";
					   		document.getElementById("ola").innerHTML+= `<div class='col-md-10'> <div class='form-group'> <h5> `+resumes[i]+`</h5>
								<input class='form-control' placeholder='Info1' id='`+values[i]+`' type='text' value='`+resp+`' > </div> </div> `;
					  			 }   
							}
					   else alert("Você não digitou um cnpj valido") 
					});

					
					}
				else alert("Você não digitou um cnpj valido");
			}
		

		function EntrarButton()
		{	var pass = document.getElementById("pass").value;
			pass = rstr_md5(pass);
			
			if (pass === mpass){
			document.getElementById("bestrow").innerHTML = "";
			document.getElementById("bestrow").innerHTML = "<div class='col-md-8 col-md-push-4 col-sm-12 col-sm-push-0 col-xs-12 col-xs-push-0' data-animate-effect='fadeIn'> <div class='row'> <div class='col-md-5 text-center fh5co-heading animate-box' data-animate-effect='fadeIn'>  </div> <div class='col-md-11'> <h2>Selecione a ação</h2> <button class='btn btn-primary' onclick='Adcionarbt()'>Cadastrar empresa </button> <button class='btn btn-primary' onclick='Editarbt()' >Editar empresa</button> </div> </div> </div><div class='col-md-8 col-md-push-4 col-sm-12 col-sm-push-0 col-xs-12 col-xs-push-0' data-animate-effect='fadeIn'></div>";
		}
			else alert("SENHA INCORRETA");
			
		}
		function FixNumber(element)
		{
			var value = (parseInt(element.value)).toLocaleString('pt-BR', { style: 'currency', currency: 'BRL' });
			value = value.replace('R$',"");
			element.value=value;
		}
		function Adcionarbt() {
			// body...
			document.getElementById("bestrow").innerHTML = `<div class='container'> <div class='row'> <div class='col-md-8 col-md-push-1 col-sm-12 col-sm-push-0 col-xs-12 col-xs-push-0'>
					<div class='row'> <form action='controls.php?servID=33' method='post' enctype='multipart/form-data'> <div class='col-md-10'> <div class='form-group'> 
						<legend>CNPJ</legend>
					<input class='form-control' placeholder='CNPJ' id="cnpjj" onblur="getCNPJinf(value)" name='title' type='text' value='' maxlength='14' required='required'> </div> </div> <div class='col-md-12'> <div class='form-group'>
				 <legend>Informações Da Empresa</legend> </div> </div> 
				 <div id ="ola" class='col-md-10'>
				 	<p> Digite o CNJP</p>
				 </div>

				 <div class='col-md-10'> <div class='form-group'> 
						<legend>Informações da Pessoa física</legend> 
					<input class='form-control' placeholder='Nome' id="name"  name='name' type='text' value='' maxlength='200' required='required'>
					 </div> </div>
				 <div class='col-md-10'> <div class='form-group'> 
						
					<input class='form-control' placeholder='CPF' id="cpf"  name='cpf' type='number' value='' min='10000000000' max='99999999999' required='required'>
					 </div> </div>
					 <div class='col-md-10'> <div class='form-group'>
					 <input class='form-control' placeholder='Título de Eleitor' id="ele"  name='ele' type='number' value='' required='required'>
					 </div> </div>
					 <div class='col-md-10'> <div class='form-group'>
				 	  <input class='form-control' id='end' name='end' value='' placeholder='Endereço' type='text' maxlength='80' required='required'> 
				 	</div> </div>
				 	  <div class='col-md-10'> <div class='form-group'>
				 	  <input class='form-control' id='tel' name='tel' value='' placeholder='Telefone' type='text' maxlength='15' required='required'> </div> </div>
				 	   <div class='col-md-10'> <div class='form-group'>
				 	  <input class='form-control' id='cel' name='cel' value='' placeholder='Celular' type='text' maxlength='15' required='required'> </div> </div>
				 	  <div class='col-md-10'> <div class='form-group'>
				 	  <input class='form-control' id='email' name='email' value='' placeholder='Email' type='text' maxlength='15' required='required'> </div> </div>
				 	 <div class='col-md-12'> <div class='form-group'>
				 <legend>Informações para Gerar o Simples Nacional</legend> </div> </div> 
				 	<div class='col-md-10'> <div class='form-group'>
				 	<p>Emitir com:</p>
				 	 <input type='radio' name='neg' value='0' checked> Regime de competência    <br><input type='radio' name='neg' value='1'> Regime de caixa
				 	  </div> </div>

				 	  <div class='col-md-12'> <div class='form-group'>
				 	  <p>Emitir com:</p>
				 	  <div id ="tabelas"></div>
				 	  </div> </div>
				 	  <div class='col-md-10'> <div class='form-group'>
				 	  	<legend> Confirmação</legend>
				 	  <input type='checkbox' name='pront' value="1"> Pronto para emitir <br></div> </div>
				 	  <div class='col-md-10'> <div class='form-group'>
				 	  <input class='form-control' placeholder='Senha' id="senha"  name='senha' type='password' value='' maxlength='16' required='required'></div></div>
				 	   <div class='col-md-12 text-center'> <div class='form-group'> <input value='Cadastrar' onclick='test()' class='btn btn-primary' type='submit'></div></div>`;
				 	   var tabsvalues =["Sem substituição tributária/tributação monofásica/antecipação com encerramento de tributação (o substituto tributário do ICMS deve utilizar essa opção)","Com substituição tributária/tributação monofásica/antecipação com encerramento de tributação (o substituído tributário do ICMS deve utilizar essa opção)","Revenda de mercadorias para o exterior","Sem substituição tributária/tributação monofásica/antecipação com encerramento de tributação (o substituto tributário do ICMS deve utilizar essa opção)","Com substituição tributária/tributação monofásica/antecipação com encerramento de tributação (o substituído tributário do ICMS deve utilizar essa opção)","Venda de mercadorias industrializadas pelo contribuinte para o exterior","Locação de bens móveis, exceto para o exterior","Locação de bens móveis para o exterior","Escritórios de serviços contábeis autorizados pela legislação municipal a pagar o ISS em valor fixo em guia do Município","Sujeitos ao fator “r”, sem retenção/substituição tributária de ISS, com ISS devido a outro(s) Município(s)","Sujeitos ao fator “r”, sem retenção/substituição tributária de ISS, com ISS devido ao próprio Município do estabelecimento","Sujeitos ao fator “r”, com retenção/substituição tributária de ISS","Não sujeitos ao fator “r” e tributados pelo Anexo III, sem retenção/substituição tributária de ISS, com ISS devido a outro(s) Município(s)","Não sujeitos ao fator “r” e tributados pelo Anexo III, sem retenção/substituição tributária de ISS, com ISS devido ao próprio Município do estabelecimento","Não sujeitos ao fator “r” e tributados pelo Anexo III, com retenção/substituição tributária de ISS","Sujeitos ao Anexo IV, sem retenção/substituição tributária de ISS, com ISS devido a outro(s) Município(s)","Sujeitos ao Anexo IV, sem retenção/substituição tributária de ISS, com ISS devido ao próprio Município do estabelecimento","Sujeitos ao Anexo IV, com retenção/substituição tributária de ISS","Serviços da área da construção civil relacionados nos subitens 7.02 e 7.05 da lista anexa à LC 116/2003 e tributados pelo Anexo III, sem retenção/substituição tributária de ISS, com ISS devido a outro(s) Município(s)","Serviços da área da construção civil relacionados nos subitens 7.02 e 7.05 da lista anexa à LC 116/2003 e tributados pelo Anexo III, sem retenção/substituição tributária de ISS, com ISS devido ao próprio Município do estabelecimento","Serviços da área da construção civil relacionados nos subitens 7.02 e 7.05 da lista anexa à LC 116/2003 e tributados pelo Anexo III, com retenção/substituição tributária de ISS","Serviços da área da construção civil relacionados nos subitens 7.02 e 7.05 da lista anexa à LC 116/2003 e tributados pelo Anexo IV, sem retenção/substituição tributária de ISS, com ISS devido a outro(s) Município(s)","Serviços da área da construção civil relacionados nos subitens 7.02 e 7.05 da lista anexa à LC 116/2003 e tributados pelo Anexo IV, sem retenção/substituição tributária de ISS, com ISS devido ao próprio Município do estabelecimento","Serviços da área da construção civil relacionados nos subitens 7.02 e 7.05 da lista anexa à LC 116/2003 e tributados pelo Anexo IV, com retenção/substituição tributária de ISS","Serviços de transporte coletivo municipal rodoviário, metroviário, ferroviário e aquaviário de passageiros, sem retenção/substituição tributária de ISS, com ISS devido a outro(s) Município(s)","Serviços de transporte coletivo municipal rodoviário, metroviário, ferroviário e aquaviário de passageiros, sem retenção/substituição tributária de ISS, com ISS devido ao próprio Município do estabelecimento","Serviços de transporte coletivo municipal rodoviário, metroviário, ferroviário e aquaviário de passageiros, com retenção/substituição tributária de ISS","Escritórios de serviços contábeis autorizados pela legislação municipal a pagar o ISS em valor fixo em guia do Município","Sujeitos ao fator “r”","Não sujeitos ao fator “r” e tributados pelo Anexo III","Sujeitos ao Anexo IV","Serviços da área da construção civil relacionados nos subitens 7.02 e 7.05 da lista anexa à LC 116/2003 e tributados pelo Anexo III","Serviços da área da construção civil relacionados nos subitens 7.02 e 7.05 da lista anexa à LC 116/2003 e tributados pelo Anexo IV","Transporte sem substituição tributária de ICMS (o substituto tributário deve utilizar essa opção)","Transporte com substituição tributária de ICMS (o substituído tributário deve utilizar essa opção)","Comunicação sem substituição tributária de ICMS (o substituto tributário deve utilizar essa opção)","Comunicação com substituição tributária de ICMS (o substituído tributário deve utilizar essa opção)","Transporte","Comunicação","Sem retenção/substituição tributária de ISS, com ISS devido a outro(s) Município(s)","Sem retenção/substituição tributária de ISS, com ISS devido ao próprio Município do estabelecimento","Com retenção/substituição tributária de ISS","Atividades com incidência simultânea de IPI e de ISS para o exterior"];
				 	   for(var i =0;i<tabsvalues.length;i++)
		document.getElementById("tabelas").innerHTML+="<br><input type='checkbox' name='tabs' value='"+i+"'> "+tabsvalues[i]+" <br>";
			
		}
		function test()
		{
			var a =document.getElementById("price").value;		
			var times = a.split('.').length-1;
			for (var i =0;i<times;i++)a = a.replace('.',"");
			var est = document.getElementById('est').value;
			var city = document.getElementById('ct').value;

			document.getElementById('end').value= document.getElementById('end').value+","+city+","+est;

			a= a.split(",");
			document.getElementById("price").value= a[0];
			//alert(a[0]);
		}
		
		function editaropen(infos) {
			
			var infs = infos.split("|");
			console.log(infs);
			var end= infs[5].split(",");
			//alert(infs[2]);
			infs[2]= infs[2].substring(0,infs[2].length-1);
			var b="<div class='container'> <div class='row'> <div class='col-md-8 col-md-push-1 col-sm-12 col-sm-push-0 col-xs-12 col-xs-push-0'> <div class='row'> <form action='controls.php?servID=10&id="+infs[0]+"' method='post' enctype='multipart/form-data'> <div class='col-md-10'> <div class='form-group'> <input class='form-control' placeholder='Título' name='title' type='text' value='"+infs[1]+"' maxlength='80' required='required'> </div> </div> <div class='col-md-12'> <div class='form-group'> <legend>Informações</legend> </div> </div> <div class='col-md-4'> <div class='form-group'> <i class='icon-money'> </i><input id ='price' onchange='FixNumber(this)' name='price' value='"+infs[2]+"' type='text' required='required'></input> </div> </div> <div class='col-md-4'> <div class='form-group'> <input type='radio' name='neg' value='0' checked> À Venda <input type='radio' name='neg' value='1'> Aluguel </div> </div> <div class='col-md-12'> <div class='form-group'> <textarea name='dcurt' class='form-control' id=''  cols='30' rows='3' placeholder='Descrição curta' maxlength='135' required='required'>"+infs[3]+"</textarea> </div> </div> <div class='col-md-12'> <div class='form-group'> <textarea name='dlong'  class='form-control' id='' cols='30' rows='8' placeholder='Descrição completa' required='required'>"+infs[4]+"</textarea> </div> </div> <div class='col-md-12'> <div class='form-group'> <legend>Localização</legend> </div> </div> <div class='col-md-6'> <div class='form-group'> <input class='form-control' id='end' name='end' value='"+end[0]+"' placeholder='Endereço' type='text' maxlength='80' required='required'> </div> </div> <div class='col-md-2'> <div class='form-group'> <input class='form-control' value='"+end[3]+"' name='num' placeholder='Num' type='text' required='required'> </div> </div> <div class='col-md-6'> <div class='form-group'> <input class='form-control' id='ct' value='"+end[1]+"' placeholder='Cidade' type='text' maxlength='80' required='required'> </div> </div><div class='col-md-2'> <div class='form-group'> <input class='form-control' value='"+end[2]+"' id='est' placeholder='Estado' type='text' maxlength='2' required='required'> </div> </div> <div class='col-md-5'> <div class='form-group'> <input class='form-control' value='"+end[5]+"' name='cep' placeholder='CEP'  type='text' required='required'> </div> </div> <div class='col-md-4'> <div class='form-group'> <input class='form-control' value='"+end[4]+"' name='bairro' placeholder='Bairro' type='text' required='required'> </div> </div> <div class='col-md-12'> <div class='form-group'> <legend>Detalhes</legend> </div> </div> <div class='col-md-4'> <div class='form-group'> <input class='form-control' value='"+infs[6]+"' name='tipo' placeholder='Tipo (loja,Casa,apartamento)' type='text' required='required'> </div> </div> <div class='col-md-4'> <div class='form-group'> <input class='form-control' value='"+infs[7]+"' min='0' name='taman' placeholder='Tamanho m²' type='number' required='required'> </div> </div>  <div class='col-md-12'> <div class='form-group'> <input value='Editar Imóvel' onclick='test()' class='btn btn-primary' type='submit'> <button class='btn btn-primary' onclick='Cancel()'>Cancelar</button> </div> </div> </form> </div> </div> </div>";
			document.getElementById("bestrow").innerHTML = b;
		}



		//var value = 



		function Editarbt() {
			document.getElementById("bestrow").innerHTML = "";
			for (var i =0;i<imvs.length;i++)
		{
			if (imvs[i]!="")
			{
				ShowHouses(imvs[i]);
			}

		}
			document.getElementById("bestrow").innerHTML+="<div class='col-md-8 col-md-push-4 col-sm-4 col-sm-push-3 col-xs-12 col-xs-push-0' data-animate-effect='fadeIn'><button class='btn btn-primary' onclick='Cancel()'>Cancelar</button></div>";
		}
		function Cancel()
		{
			document.getElementById("bestrow").innerHTML = "";
			document.getElementById("bestrow").innerHTML = "<div class='col-md-8 col-md-push-4 col-sm-12 col-sm-push-0 col-xs-12 col-xs-push-0' data-animate-effect='fadeIn'> <div class='row'> <div class='col-md-5 text-center fh5co-heading animate-box' data-animate-effect='fadeIn'>  </div> <div class='col-md-11'> <h2>Selecione a ação</h2> <button class='btn btn-primary' onclick='Adcionarbt()'>Adicionar um Imóvel</button> <button class='btn btn-primary' onclick='Editarbt()' >Editar um Imóvel</button> </div> </div> </div><div class='col-md-8 col-md-push-4 col-sm-12 col-sm-push-0 col-xs-12 col-xs-push-0' data-animate-effect='fadeIn'>";
		}
		function edit(id)
		{
			
			var myposition;
			for (var i =0;i<a.length;i++)
			{
				if (a!=null)
				{
					if (a[i].split("|")[0]==id)
					{
						myposition=i;
					}
				}
			}
			editaropen(a[myposition]);
			
		}
		function exclui(id)
		{
			if(confirm("Você tem certeza que deseja excluir  ?"))
			{
				var form = document.createElement("form");
			    input = document.createElement("input");
				form.action = "controls.php?servID=46";
				form.method = "post"
				input.type = "hidden";
				input.name = "id";
				input.value = id;
				form.appendChild(input);
				document.body.appendChild(form);
				form.submit();
			}
		}
	
		$(function() {
  $('[type=money]').maskMoney({
    thousands: '.',
    decimal: ','
  });
})
	
   

	</script>

	

	
	<footer id="fh5co-footer" role="contentinfo">
	
		<div class="container">
			<div class="col-md-8 col-sm-12 col-sm-push-0 col-xs-12 col-xs-push-0">
				<h3>Sobre nós</h3>
					<p> A EMPRESA BLABLALBAL
 </p>				
			</div>
			

			<div class="col-md-2 col-md-push-1 col-sm-12 col-sm-push-0 col-xs-12 col-xs-push-0">
<h3>Redes socias</h3>
				<ul class="fh5co-social">					
					<li><a  target="_blank" href=""><i class="icon-facebook"></i></a></li>
					<li><a  target="_blank" href=""><i class="icon-google-plus"></i></a></li>					
				</ul>
			</div>
			
			<div class="col-md-12 fh5co-copyright text-center">
				<p><p>&copy; 2018 All Rights Reserved.<span>Desenvolvido por Nathan Vieira de Magalhães <span><a target="_blank" href="https://nathanvmag.github.io"<p>Website </p></a> </p>	
					
			</div>
			
		</div>
	</footer>
	</div>
	
	
	
	

	</body>
</html>

