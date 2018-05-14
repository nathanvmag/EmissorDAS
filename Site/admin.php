
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
					<h1><a href="index.html">Emissor DAS <span>.</span></a></h1>
					<nav role="navigation">
						<ul>
							<li><a href="index.html">Início</a></li>
							
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
		var cadastrados;
		$.post('cadastro.php', { servID: 98 }, function(data) {
			console.log(data);
			cadastrados=data;
		});
		var tabsvalues =["Sem substituição tributária/tributação monofásica/antecipação com encerramento de tributação (o substituto tributário do ICMS deve utilizar essa opção)","Com substituição tributária/tributação monofásica/antecipação com encerramento de tributação (o substituído tributário do ICMS deve utilizar essa opção)","Revenda de mercadorias para o exterior","Sem substituição tributária/tributação monofásica/antecipação com encerramento de tributação (o substituto tributário do ICMS deve utilizar essa opção)","Com substituição tributária/tributação monofásica/antecipação com encerramento de tributação (o substituído tributário do ICMS deve utilizar essa opção)","Venda de mercadorias industrializadas pelo contribuinte para o exterior","Locação de bens móveis, exceto para o exterior","Locação de bens móveis para o exterior","Escritórios de serviços contábeis autorizados pela legislação municipal a pagar o ISS em valor fixo em guia do Município","Sujeitos ao fator “r”, sem retenção/substituição tributária de ISS, com ISS devido a outro(s) Município(s)","Sujeitos ao fator “r”, sem retenção/substituição tributária de ISS, com ISS devido ao próprio Município do estabelecimento","Sujeitos ao fator “r”, com retenção/substituição tributária de ISS","Não sujeitos ao fator “r” e tributados pelo Anexo III, sem retenção/substituição tributária de ISS, com ISS devido a outro(s) Município(s)","Não sujeitos ao fator “r” e tributados pelo Anexo III, sem retenção/substituição tributária de ISS, com ISS devido ao próprio Município do estabelecimento","Não sujeitos ao fator “r” e tributados pelo Anexo III, com retenção/substituição tributária de ISS","Sujeitos ao Anexo IV, sem retenção/substituição tributária de ISS, com ISS devido a outro(s) Município(s)","Sujeitos ao Anexo IV, sem retenção/substituição tributária de ISS, com ISS devido ao próprio Município do estabelecimento","Sujeitos ao Anexo IV, com retenção/substituição tributária de ISS","Serviços da área da construção civil relacionados nos subitens 7.02 e 7.05 da lista anexa à LC 116/2003 e tributados pelo Anexo III, sem retenção/substituição tributária de ISS, com ISS devido a outro(s) Município(s)","Serviços da área da construção civil relacionados nos subitens 7.02 e 7.05 da lista anexa à LC 116/2003 e tributados pelo Anexo III, sem retenção/substituição tributária de ISS, com ISS devido ao próprio Município do estabelecimento","Serviços da área da construção civil relacionados nos subitens 7.02 e 7.05 da lista anexa à LC 116/2003 e tributados pelo Anexo III, com retenção/substituição tributária de ISS","Serviços da área da construção civil relacionados nos subitens 7.02 e 7.05 da lista anexa à LC 116/2003 e tributados pelo Anexo IV, sem retenção/substituição tributária de ISS, com ISS devido a outro(s) Município(s)","Serviços da área da construção civil relacionados nos subitens 7.02 e 7.05 da lista anexa à LC 116/2003 e tributados pelo Anexo IV, sem retenção/substituição tributária de ISS, com ISS devido ao próprio Município do estabelecimento","Serviços da área da construção civil relacionados nos subitens 7.02 e 7.05 da lista anexa à LC 116/2003 e tributados pelo Anexo IV, com retenção/substituição tributária de ISS","Serviços de transporte coletivo municipal rodoviário, metroviário, ferroviário e aquaviário de passageiros, sem retenção/substituição tributária de ISS, com ISS devido a outro(s) Município(s)","Serviços de transporte coletivo municipal rodoviário, metroviário, ferroviário e aquaviário de passageiros, sem retenção/substituição tributária de ISS, com ISS devido ao próprio Município do estabelecimento","Serviços de transporte coletivo municipal rodoviário, metroviário, ferroviário e aquaviário de passageiros, com retenção/substituição tributária de ISS","Escritórios de serviços contábeis autorizados pela legislação municipal a pagar o ISS em valor fixo em guia do Município","Sujeitos ao fator “r”","Não sujeitos ao fator “r” e tributados pelo Anexo III","Sujeitos ao Anexo IV","Serviços da área da construção civil relacionados nos subitens 7.02 e 7.05 da lista anexa à LC 116/2003 e tributados pelo Anexo III","Serviços da área da construção civil relacionados nos subitens 7.02 e 7.05 da lista anexa à LC 116/2003 e tributados pelo Anexo IV","Transporte sem substituição tributária de ICMS (o substituto tributário deve utilizar essa opção)","Transporte com substituição tributária de ICMS (o substituído tributário deve utilizar essa opção)","Comunicação sem substituição tributária de ICMS (o substituto tributário deve utilizar essa opção)","Comunicação com substituição tributária de ICMS (o substituído tributário deve utilizar essa opção)","Transporte","Comunicação","Sem retenção/substituição tributária de ISS, com ISS devido a outro(s) Município(s)","Sem retenção/substituição tributária de ISS, com ISS devido ao próprio Município do estabelecimento","Com retenção/substituição tributária de ISS","Atividades com incidência simultânea de IPI e de ISS para o exterior"];
			


		function ShowEmpresas(info){
			var infs = info.split("|");
			
			var b = `<div class='col-md-12 text-center col-sm-12 col-sm-push-0 col-xs-12 col-xs-push-0' data-animate-effect='fadeIn'> 
						<div class='form-group' >
						 <h4> <i class ='icon-document'> </i> CNPJ = `+ infs[0]+ ` &nbsp;&nbsp;&nbsp; <i class ='icon-user'> </i>  `+infs[1]+` &nbsp;&nbsp;&nbsp; <i class ='icon-document'> </i> CPF =`+infs[2]+`
						 	<button class='btn btn-primary btn-outline' onclick='edit(`+infs[0]+`)' > Editar</button> 
						 	<button class='btn btn-primary btn-outline' onclick='exclui(`+infs[0]+`)' >Excluir </button>
						 </span> </h4> </div> </div></div>`  ;

			document.getElementById("bestrow").innerHTML += b;
		}
		var cnpjj;
		var fezCnpj;
		function getCNPJinf(cnpj)
			{
				cnpjj= cnpj;
				document.getElementById("ola").innerHTML="";
				if (cnpj.length==14&&validarCNPJ(cnpj))
				{					
					var url= "https://www.receitaws.com.br/v1/cnpj/"+cnpj;
					document.getElementById("ola").innerHTML="<img src='https://zippy.gfycat.com/SkinnySeveralAsianlion.gif' width=50px ></img>";
					$.post('cnpj.php', { url: url }, function(data) {
					   try{
					   var obj = JSON.parse(data);

					   if (obj.status=="OK")
					   {
					   	fezCnpj=true;
					   	 var values = [ "tipo","abertura","nome","fantasia","natureza_juridica",
                        "logradouro","numero","complemento","cep","bairro","municipio","uf","email","telefone",
                    "efr","situacao","data_situacao","motivo_situacao","situacao_especial","data_situacao_especial"];  
                        

                    	 var resumes = [ "TIPO:", "DATA DE ABERTURA:","NOME EMPRESARIAL:",
                    "TÍTULO DO ESTABELECIMENTO (NOME DE FANTASIA):","CÓDIGO E DESCRIÇÃO DA NATUREZA JURÍDICA:","LOGRADOURO:","NÚMERO:","COMPLEMENTO:","CEP:",
                    "BAIRRO/DISTRITO:","MUNICÍPIO:","UF:","ENDEREÇO ELETRÔNICO:","TELEFONE:","ENTE FEDERATIVO RESPONSÁVEL (EFR):","SITUAÇÃO CADASTRAL:",
                    "DATA DA SITUAÇÃO CADASTRAL:","MOTIVO DE SITUAÇÃO CADASTRAL:","SITUAÇÃO ESPECIAL:","DATA DA SITUAÇÃO ESPECIAL:" ];

                    	var atp =  obj.atividade_principal[0]["code"]+" - "+ obj.atividade_principal[0]["text"];  
                    	var ats="";
                    	for(var i =0; i<obj["atividades_secundarias"].length;i++)
                    	{
                    		ats+=obj["atividades_secundarias"][i]["code"]+" - "+ obj["atividades_secundarias"][i]["text"]+"\n";
                    	}     	
                    	//console.log(ats);

                    		document.getElementById("ola").innerHTML="";
                    		for(var i=0;i<values.length;i++){
                    			var resp= obj[values[i]]!=""?obj[values[i]]:"---";
                    			if (i==4)
                    			{
                    				document.getElementById("ola").innerHTML+= `<div class='col-md-10'> <div class='form-group'> <h5> CÓDIGO E DESCRIÇÃO DA ATIVIDADE ELETRÔNICA PRINCIPAL:</h5>
								<input class='form-control' placeholder='CÓDIGO E DESCRIÇÃO DA ATIVIDADE ELETRÔNICA PRINCIPAL' id='atp' type='text' value='`+atp+`' > </div> </div> `;
									document.getElementById("ola").innerHTML+= `<div class='col-md-10'> <div class='form-group'> <h5> CÓDIGO E DESCRIÇÃO DAS ATIVIDADES ELETRÔNICAS SECUNDARIAS: </h5> <textarea name='ats'  class='form-control' id='ats' cols='60' rows='4' placeholder='CÓDIGO E DESCRIÇÃO DAS ATIVIDADES ELETRÔNICAS SECUNDARIAS:' required='required'>`+ ats+`</textarea> </div> </div>	`;	
                    			}
					   			document.getElementById("ola").innerHTML+= `<div class='col-md-10'> <div class='form-group'> <h5> `+resumes[i]+`</h5>
								<input class='form-control' placeholder='Info1' id='`+values[i]+`' type='text' value='`+resp+`' > </div> </div> `;
					  			 }   
							}
					   else{ alert("Você não digitou um cnpj valido 3") 
					   		document.getElementById("ola").innerHTML="<p> Digite um CNPJ válido.</p>";
					   		fezCnpj=false;
					}}
					catch(err){alert("Você não digitou um cnpj valido 2 ") 
					   		document.getElementById("ola").innerHTML="<p> Digite um CNPJ válido.</p>";
					   		fezCnpj=false;}
					});

					
					}
				else {alert("Você não digitou um cnpj valido 1");
					  document.getElementById("ola").innerHTML="<p> Digite um CNPJ válido.</p>";
					}
			}
		function trocaadmpass()
		{
			if (document.getElementById("oldpass").value!=""&&document.getElementById("npass").value!=""&&document.getElementById("npass2").value!="")
			{
				if (document.getElementById("npass").value==document.getElementById("npass2").value)
				{
					$.post('login.php', { servID: 1102,pass:document.getElementById("oldpass").value,pass1:document.getElementById("npass").value }, function(data) {
						if(data=="OK")
						{
							alert("Senha alterada com sucesso");
							document.getElementById("bestrow").innerHTML = "";
							document.getElementById("bestrow").innerHTML = "<div class='col-md-8 col-md-push-3 col-sm-12 col-sm-push-0 col-xs-12 col-xs-push-0' data-animate-effect='fadeIn'> <div class='row'> <div class='col-md-5 text-center fh5co-heading animate-box' data-animate-effect='fadeIn'>  </div> <div class='col-md-11'> <h2>Selecione a ação</h2> <button class='btn btn-primary' onclick='Adcionarbt()'>Cadastrar empresa </button> <button class='btn btn-primary' id='editemp' onclick='Editarbt()' >Editar empresa</button> <button class='btn btn-primary' id='editpass' onclick='Editpass()' >Alterar Senha</button></div> </div> </div><div class='col-md-8 col-md-push-4 col-sm-12 col-sm-push-0 col-xs-12 col-xs-push-0' data-animate-effect='fadeIn'></div>";
							if (cadastrados=="-")document.getElementById("editemp").disabled=true;
						}
						else if (data=="N")
						{
							alert("Senha antiga INCORRETA");
						}
						
					});
						

				}
				else alert("A nova senha e a confirmação não sao iguais!")

			}
			else alert("Preencha todos os campos");
		}

		function EntrarButton()
		{	var pass = document.getElementById("pass").value;
			
			//pass = rstr_md5(pass);
			$.post('login.php', { servID: 3092,pass:pass }, function(data) {
				console.log(data);
				if(data == "OK")
				{
					document.getElementById("bestrow").innerHTML = "";
				document.getElementById("bestrow").innerHTML = "<div class='col-md-8 col-md-push-3 col-sm-12 col-sm-push-0 col-xs-12 col-xs-push-0' data-animate-effect='fadeIn'> <div class='row'> <div class='col-md-5 text-center fh5co-heading animate-box' data-animate-effect='fadeIn'>  </div> <div class='col-md-11'> <h2>Selecione a ação</h2> <button class='btn btn-primary' onclick='Adcionarbt()'>Cadastrar empresa </button> <button class='btn btn-primary' id='editemp' onclick='Editarbt()' >Editar empresa</button> <button class='btn btn-primary' id='editpass' onclick='Editpass()' >Alterar Senha</button></div> </div> </div><div class='col-md-8 col-md-push-4 col-sm-12 col-sm-push-0 col-xs-12 col-xs-push-0' data-animate-effect='fadeIn'></div>";
				if (cadastrados=="-")document.getElementById("editemp").disabled=true;
				}
				else alert("SENHA INCORRETA");
			});
			
			
			
		}
		function Editpass()
		{
			document.getElementById("bestrow").innerHTML = "";
			document.getElementById("bestrow").innerHTML = "<div class='col-md-8 col-md-push-3 col-sm-12 col-sm-push-0 col-xs-12 col-xs-push-0' data-animate-effect='fadeIn'> <div class='row'> <div class='col-md-5 text-center fh5co-heading animate-box' data-animate-effect='fadeIn'>  </div> <div class='col-md-11'> <h2>Selecione a ação</h2> <button class='btn btn-primary' onclick='editpass2()'>Editar Senha </button> <button class='btn btn-primary' id='editemp' onclick='editemail()' >Editar email de solicitação</button> </div> </div> </div><div class='col-md-8 col-md-push-4 col-sm-12 col-sm-push-0 col-xs-12 col-xs-push-0' data-animate-effect='fadeIn'></div>";
			document.getElementById("bestrow").innerHTML+="<div class='col-md-8 col-md-push-4 col-sm-4 col-sm-push-3 col-xs-12 col-xs-push-0' data-animate-effect='fadeIn'><button class='btn btn-primary' onclick='Cancel()'>Cancelar</button>";
		}
		function editemail()
		{
			$.post('login.php', { servID: 3030, }, function(data) {
				if(data!="error"){
			document.getElementById("bestrow").innerHTML = ` <div class='container'> <div class='row'> <div class='col-md-8 col-md-push-1 col-sm-12 col-sm-push-0 col-xs-12 col-xs-push-0'>
					<div class='row'>  <div class='col-md-6 col-md-push-4'> <div class='form-group'> 
						<legend>Email para notificações</legend>
					<input class='form-control' placeholder='Email' id="emailnot" name='title' type='text' value='`+data+`'  required='required'> <h5><br></h5>
						<button class="btn btn-primary" onclick="changeemail()">Trocar email</button>
						<button class='btn btn-primary' onclick='Cancel()'>Cancelar</button>
				</div> </div> 
					</div> </div> </div>  </div>`;
					}
			else alert("Erro ao obter email");
				});
						
		}
		function changeemail()
		{
			if (document.getElementById("emailnot").value!=""&&validateEmail(document.getElementById("emailnot").value))
			{
				$.post('login.php', { servID: 9021,email: document.getElementById("emailnot").value}, function(data) {
				if(data=="OK"){
					alert("Email alterado com sucesso");
					document.getElementById("bestrow").innerHTML = "";
					document.getElementById("bestrow").innerHTML = "<div class='col-md-8 col-md-push-3 col-sm-12 col-sm-push-0 col-xs-12 col-xs-push-0' data-animate-effect='fadeIn'> <div class='row'> <div class='col-md-5 text-center fh5co-heading animate-box' data-animate-effect='fadeIn'>  </div> <div class='col-md-11'> <h2>Selecione a ação</h2> <button class='btn btn-primary' onclick='Adcionarbt()'>Cadastrar empresa </button> <button class='btn btn-primary' id='editemp' onclick='Editarbt()' >Editar empresa</button> <button class='btn btn-primary' id='editpass' onclick='Editpass()' >Alterar Senha</button></div> </div> </div><div class='col-md-8 col-md-push-4 col-sm-12 col-sm-push-0 col-xs-12 col-xs-push-0' data-animate-effect='fadeIn'></div>";
				}
				else alert("Erro no sistema");
			});
			}
			else alert("Preencha o email corretamente");
		}
		function validateEmail(email) {
		  var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
		  return re.test(email);
		}
		function editpass2()
		{
			document.getElementById("bestrow").innerHTML = "";
			document.getElementById("bestrow").innerHTML = `<div class='container'> <div class='row'> <div class='col-md-8 col-md-push-1 col-sm-12 col-sm-push-0 col-xs-12 col-xs-push-0'>
					<div class='row'>  <div class='col-md-6 col-md-push-4'> <div class='form-group'> 
						<legend>Senha antiga</legend>
					<input class='form-control' placeholder='Senha antiga' id="oldpass" name='title' type='password' value='' maxlength='14' required='required'> 
						
						<legend>Nova Senha</legend>
					<input class='form-control ' placeholder='Nova senha' id="npass" name='title' type='password' value='' maxlength='14' required='required'>
					<input class='form-control' placeholder='Confirmar senha' id="npass2" name='title' type='password' value='' maxlength='14' required='required'> <h5><br></h5>
					<button class='btn btn-primary' onclick="trocaadmpass()" >Trocar senha </button>
					<button class='btn btn-primary' onclick='Cancel()'>Cancelar</button>
				</div> </div> 
					</div> </div> </div>  </div>`;

		}
		function Adcionarbt() {
			// body...
			document.getElementById("bestrow").innerHTML = `<div class='container'> <div class='row'> <div class='col-md-8 col-md-push-1 col-sm-12 col-sm-push-0 col-xs-12 col-xs-push-0'>
					<div class='row'> <form action='' method='post' enctype='multipart/form-data'> <div class='col-md-10'> <div class='form-group'> 
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
				 	  <input class='form-control' id='cep2' name='cep' value='' placeholder='CEP' type='number' min='100000000' max ='999999999' required='required'> 
				 	</div> </div>
					 <div class='col-md-10'> <div class='form-group'>
				 	  <input class='form-control' id='end' name='end' value='' placeholder='Endereço' type='text' maxlength='80' required='required'> 
				 	</div> </div>
				 	
				 	<div class='col-md-10'> <div class='form-group'>
				 	  <input class='form-control' id='bairro2' name='bairro' value='' placeholder='Bairro' type='text' maxlength='80' required='required'> 
				 	</div> </div>
				 	<div class='col-md-10'> <div class='form-group'>
				 	  <input class='form-control' id='cid' name='cid' value='' placeholder='Cidade' type='text' maxlength='80' required='required'> 
				 	</div> </div>
				 	<div class='col-md-10'> <div class='form-group'>
				 	  <input class='form-control' id='cap' name='cap' value='' placeholder='Capital' type='text' maxlength='80' required='required'> 
				 	</div> </div>
				 	  <div class='col-md-10'> <div class='form-group'>
				 	  <input class='form-control' id='tel' name='tel' value='' placeholder='Telefone' type='text' maxlength='15' required='required'> </div> </div>
				 	   <div class='col-md-10'> <div class='form-group'>
				 	  <input class='form-control' id='cel' name='cel' value='' placeholder='Celular' type='text' maxlength='15' required='required'> </div> </div>
				 	  <div class='col-md-10'> <div class='form-group'>
				 	  <input class='form-control' id='email2' name='email' value='' placeholder='Email' type='text' maxlength='60' required='required'> </div> </div>
				 	 <div class='col-md-12'> <div class='form-group'>
				 <legend>Informações para Gerar o Simples Nacional</legend> </div> </div> 
				 	<div class='col-md-10'> <div class='form-group'>
				 	<p>Emitir com:</p>
				 	 <input type='radio' name='neg' id='regim' value='0' checked> Regime de competência    <br><input type='radio' name='neg' value='1'> Regime de caixa
				 	  </div> </div>

				 	  <div class='col-md-12'> <div class='form-group'>
				 	  <p>Usar seguintes tabelas :</p>
				 	  <div id ="tabelas"></div>
				 	  </div> </div>
				 	  <div class='col-md-10'> <div class='form-group'>
				 	  	<legend> Confirmação</legend>
				 	  <input type='checkbox' name='pront' id="pront" value="1"> Pronto para emitir <br></div> </div>
				 	  <div class='col-md-10'> <div class='form-group'>
				 	  <h5> Por padrão a senha inicial de cadastro é 123456</h>
				 	  <input class='form-control' placeholder='Senha do Usuario' id="senha"  name='senha' type='password' value='123456' maxlength='16' required='required'></div></div>
				 	   <div class='col-md-12 text-center'> <div class='form-group'>
				 	    <input value='Cadastrar' type='submit' class='btn btn-primary' onclick="cadastro()"></div></div>`;
				 	   var septabs=["Revenda de mercadorias, exceto para o exterior","Venda de mercadorias industrializadas pelo contribuinte, exceto para o exterior"," Prestação de Serviços, exceto para o exterior", "Prestação de Serviços relacionados nos subitens 7.02, 7.05 e 16.1 da lista anexa à LC 116/2003, exceto para o exterior","Prestação de Serviços para o exterior","Prestação de Serviços relacionados nos subitens 7.02 e 7.05 da lista anexa à LC 116/2003, para o exterior","Serviços de comunicação; de transporte intermunicipal e interestadual de carga; e de transporte intermunicipal e interestadual de passageiros autorizados no inciso VI do art. 17 da LC 123, exceto para o exterior","Serviços de comunicação; de transporte intermunicipal e interestadual de carga; e de transporte intermunicipal e interestadual de passageiros autorizados no inciso VI do art. 17 da LC 123, para o exterior","Atividades com incidência simultânea de IPI e de ISS, exceto para o exterior"];
				 		document.getElementById("tabelas").innerHTML+="<h5>"+septabs[0]+":</h5>";
				 		for(var i =0;i<tabsvalues.length;i++){
				 			if (i==3)document.getElementById("tabelas").innerHTML+="<br><h5>"+septabs[1]+":</h5>";				 			
				 			else if (i==8)document.getElementById("tabelas").innerHTML+="<br><h5>"+septabs[2]+":</h5>";				 			
				 			else if (i==18)document.getElementById("tabelas").innerHTML+="<br><h5>"+septabs[3]+":</h5>";				 			
				 			else if (i==27)document.getElementById("tabelas").innerHTML+="<br><h5>"+septabs[4]+":</h5>";				 			
				 			else if (i==31)document.getElementById("tabelas").innerHTML+="<br><h5>"+septabs[5]+":</h5>";				 			
				 			else if (i==33)document.getElementById("tabelas").innerHTML+="<br><h5>"+septabs[6]+":</h5>";
				 			else if (i==37)document.getElementById("tabelas").innerHTML+="<br><h5>"+septabs[7]+":</h5>";
				 			else if (i==39)document.getElementById("tabelas").innerHTML+="<br><h5>"+septabs[8]+":</h5>";
				 		if((i>=0&&i<2)||(i>2&&i<5)||(i>7&&i<18)||(i>=18&&i<27)||(i>=27&&i<31)
				 			||(i>=31&&i<33)|| (i>=33&&i<37)||(i>=37&&i<39)||(i>=39&&i<42))
						document.getElementById("tabelas").innerHTML+="<div class ='col-md-offset-1'><input type='checkbox' name='tabs' value='"+i+"'> "+tabsvalues[i]+" </div>";
						else document.getElementById("tabelas").innerHTML+="<div class ='col-md-offset-0'><input type='checkbox' name='tabs' value='"+i+"'> "+tabsvalues[i]+" </div>";
			}
		}
		function cadastro()
		{
			var incomplet=false;
			if(fezCnpj){
			var ids=["cnpjj","name","cpf","ele","cep2","end","bairro2","cid","cap","tel","cel","email2","senha"];
			var values=new Array(ids.length);
			for (var i =0;i<ids.length;i++)
			{

				values[i]= document.getElementById(ids[i]).value!=""?document.getElementById(ids[i]).value:"---";
				if((i==0||i==1||i==ids.length-1)&&values[i]=="---")incomplet=true;
			}
			var cnpjinfo=""
			var classnpjinfo=""
			try{
			var valuescnpj = [ "tipo","abertura","nome","fantasia","natureza_juridica",
                        "logradouro","numero","complemento","cep","bairro","municipio","uf","email","telefone",
                    "efr","situacao","data_situacao","motivo_situacao","situacao_especial","data_situacao_especial"];  
			for (var i=0;i<valuescnpj.length+2;i++){
				if (i==valuescnpj.length)
					break;
				//console.log(valuescnpj[i]);
				classnpjinfo+=document.getElementById(valuescnpj[i]).value+"¬";
			}
			classnpjinfo+=document.getElementById("atp").value+"¬";
			classnpjinfo+=document.getElementById("ats").value;
		}
		catch(err){}
			var neg;
			for (var i=0;i<document.getElementsByName("neg").length;i++)
			{
				if (document.getElementsByName("neg")[i].checked)
				neg =i;
			}
			var tabels=[];
			for (var i=0;i<document.getElementsByName("tabs").length;i++)
			{
				if (document.getElementsByName("tabs")[i].checked)
				{
					tabels.push(i);
				}
			}
			var ready = document.getElementById("pront").checked?1:0;
			if (tabels.length==0)if(!confirm("Você não selecionou nenhuma tabela, deseja prosseguir?")){
				incomplet=true;
			}
			if(incomplet){alert("Você não selecionou os dados principais");}
			else {
				//console.log(values);
				//console.log(classnpjinfo);
				//console.log(neg);
				//console.log(ready);
				//console.log(tabels);
				ntab="";
				if(tabels.length==0){
					ntab="-";
				}
				else {
					for(var i=0;i<tabels.length;i++)
					{
						ntab+=tabels[i]+",";
					}
				}
				$.post('cadastro.php', { servID: 39 ,cnpj:values[0],infemp:classnpjinfo, nome:values[1],cpf:values[2],eletit:values[3],cep:values[4],end:values[5],bairro:values[6],cid:values[7],cap:values[8],tel:values[9],cel:values[10],email:values[11],pass:values[12],reg:neg,tabs:ntab,ready:ready}, function(data) {
					console.log(data);
					if(data =="CNPJerror"){
						alert("Este CNPJ já foi cadastrado");
					}
					else if (data=="OK")
					{
						alert("Sucesso no cadastro");
						window.location = window.location;

					}
					else 
					{
						alert("Erro no sistema");
					}
				});
			}			
			
		  }

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
			//console.log(infs);
			var cnpjvalues= infs[1].split("¬");
		//	console.log(cnpjvalues);

			var b = `<div class='container'> <div class='row'> <div class='col-md-8 col-md-push-1 col-sm-12 col-sm-push-0 col-xs-12 col-xs-push-0'>
					<div class='row'> <form action='' method='post' enctype='multipart/form-data'> <div class='col-md-10'> <div class='form-group'> 
						<legend>CNPJ</legend>
					<input class='form-control' placeholder='CNPJ' id="cnpjj" onblur="getCNPJinf(value)" name='title' type='text' value='`+infs[0]+`' disabled maxlength='14' required='required'> </div> </div> <div class='col-md-12'> <div class='form-group'>
				 <legend>Informações Da Empresa</legend> </div> </div> 
				 <div id ="ola" class='col-md-10'>
				 	<p></p>
				 </div>

				 <div class='col-md-10'> <div class='form-group'> 
						<legend>Informações da Pessoa física</legend> 
					<input class='form-control' placeholder='Nome' id="name"  name='name' type='text' value='`+infs[2]+`' maxlength='200' required='required'>
					 </div> </div>
				 <div class='col-md-10'> <div class='form-group'> 
					
					<input class='form-control' placeholder='CPF' id="cpf"  name='cpf' type='number' value='`+infs[3]+`' min='10000000000' max='99999999999' required='required'>
					 </div> </div>
					 <div class='col-md-10'> <div class='form-group'>
					 <input class='form-control' placeholder='Título de Eleitor' id="ele"  name='ele' type='number' value='`+infs[4]+`' required='required'>
					 </div> </div>

					 <div class='col-md-10'> <div class='form-group'>
				 	  <input class='form-control' id='cep2' name='cep' value='`+infs[5]+`' placeholder='CEP' type='number' min='100000000' max ='999999999' required='required'> 
				 	</div> </div>
					 <div class='col-md-10'> <div class='form-group'>
				 	  <input class='form-control' id='end' name='end' value='`+infs[6]+`' placeholder='Endereço' type='text' maxlength='80' required='required'> 
				 	</div> </div>
				 	
				 	<div class='col-md-10'> <div class='form-group'>
				 	  <input class='form-control' id='bairro2' name='bairro' value='`+infs[7]+`' placeholder='Bairro' type='text' maxlength='80' required='required'> 
				 	</div> </div>
				 	<div class='col-md-10'> <div class='form-group'>
				 	  <input class='form-control' id='cid' name='cid' value='`+infs[8]+`' placeholder='Cidade' type='text' maxlength='80' required='required'> 
				 	</div> </div>
				 	<div class='col-md-10'> <div class='form-group'>
				 	  <input class='form-control' id='cap' name='cap' value='`+infs[9]+`' placeholder='Capital' type='text' maxlength='80' required='required'> 
				 	</div> </div>
				 	  <div class='col-md-10'> <div class='form-group'>
				 	  <input class='form-control' id='tel' name='tel' value='`+infs[10]+`' placeholder='Telefone' type='text' maxlength='15' required='required'> </div> </div>
				 	   <div class='col-md-10'> <div class='form-group'>
				 	  <input class='form-control' id='cel' name='cel' value='`+infs[11]+`' placeholder='Celular' type='text' maxlength='15' required='required'> </div> </div>
				 	  <div class='col-md-10'> <div class='form-group'>
				 	  <input class='form-control' id='email2' name='email' value='`+infs[12]+`' placeholder='Email' type='text' maxlength='60' required='required'> </div> </div>
				 	 <div class='col-md-12'> <div class='form-group'>
				 <legend>Informações para Gerar o Simples Nacional</legend> </div> </div> 
				 	<div class='col-md-10'> <div class='form-group'>
				 	<p>Emitir com:</p>
				 	 <input type='radio' name='neg' id='regim1' value='0' > Regime de competência    <br><input type='radio' id='regim2' name='neg' value='1'> Regime de caixa
				 	  </div> </div>

				 	  <div class='col-md-12'> <div class='form-group'>
				 	  <p>Usar seguintes tabelas :</p>
				 	  <div id ="tabelas"></div>
				 	  </div> </div>
				 	  <div class='col-md-10'> <div class='form-group'>
				 	  	<legend> Confirmação</legend>
				 	  <input type='checkbox' name='pront' id="pront" value="1"> Pronto para emitir <br></div> </div>
				 	  <div class='col-md-10'> <div class='form-group'>
				 	  <h5> Por padrão a senha inicial de cadastro é 123456</h>
				 	  <input class='form-control' placeholder='Senha do Usuario' id="senha"  name='senha' type='password' value='`+infs[16]+`' maxlength='16' required='required'></div></div>
				 	   <div class='col-md-12 text-center'> <div class='form-group'>
				 	    <input value='Salvar alterações' type='submit' class='btn btn-primary' onclick="updatevalues()"></div></div>`;

			document.getElementById("bestrow").innerHTML = b;
			if(infs[13]=="0")document.getElementById("regim1").checked=true;
			else document.getElementById("regim2").checked=true;
			if(infs[15]=="1")document.getElementById("pront").checked=true;
			else document.getElementById("pront").checked=false;
			if(infs[14]!="-")
			{
				 ntbs= infs[14].split(",");

				 var septabs=["Revenda de mercadorias, exceto para o exterior","Venda de mercadorias industrializadas pelo contribuinte, exceto para o exterior"," Prestação de Serviços, exceto para o exterior", "Prestação de Serviços relacionados nos subitens 7.02, 7.05 e 16.1 da lista anexa à LC 116/2003, exceto para o exterior","Prestação de Serviços para o exterior","Prestação de Serviços relacionados nos subitens 7.02 e 7.05 da lista anexa à LC 116/2003, para o exterior","Serviços de comunicação; de transporte intermunicipal e interestadual de carga; e de transporte intermunicipal e interestadual de passageiros autorizados no inciso VI do art. 17 da LC 123, exceto para o exterior","Serviços de comunicação; de transporte intermunicipal e interestadual de carga; e de transporte intermunicipal e interestadual de passageiros autorizados no inciso VI do art. 17 da LC 123, para o exterior","Atividades com incidência simultânea de IPI e de ISS, exceto para o exterior"];
				 		document.getElementById("tabelas").innerHTML+="<h5>"+septabs[0]+":</h5>";
				 		for(var i =0;i<tabsvalues.length;i++){
				 			if (i==3)document.getElementById("tabelas").innerHTML+="<br><h5>"+septabs[1]+":</h5>";				 			
				 			else if (i==8)document.getElementById("tabelas").innerHTML+="<br><h5>"+septabs[2]+":</h5>";				 			
				 			else if (i==18)document.getElementById("tabelas").innerHTML+="<br><h5>"+septabs[3]+":</h5>";				 			
				 			else if (i==27)document.getElementById("tabelas").innerHTML+="<br><h5>"+septabs[4]+":</h5>";				 			
				 			else if (i==31)document.getElementById("tabelas").innerHTML+="<br><h5>"+septabs[5]+":</h5>";				 			
				 			else if (i==33)document.getElementById("tabelas").innerHTML+="<br><h5>"+septabs[6]+":</h5>";
				 			else if (i==37)document.getElementById("tabelas").innerHTML+="<br><h5>"+septabs[7]+":</h5>";
				 			else if (i==39)document.getElementById("tabelas").innerHTML+="<br><h5>"+septabs[8]+":</h5>";
				 			if(ntbs.includes(i+"")){
				 		if((i>=0&&i<2)||(i>2&&i<5)||(i>7&&i<18)||(i>=18&&i<27)||(i>=27&&i<31)
				 			||(i>=31&&i<33)|| (i>=33&&i<37)||(i>=37&&i<39)||(i>=39&&i<42))
						document.getElementById("tabelas").innerHTML+="<div class ='col-md-offset-1'><input type='checkbox' checked name='tabs' value='"+i+"'> "+tabsvalues[i]+" </div>";
						else document.getElementById("tabelas").innerHTML+="<div class ='col-md-offset-0'><input type='checkbox' checked name='tabs' value='"+i+"'> "+tabsvalues[i]+" </div>";
					}else {
						if((i>=0&&i<2)||(i>2&&i<5)||(i>7&&i<18)||(i>=18&&i<27)||(i>=27&&i<31)
				 			||(i>=31&&i<33)|| (i>=33&&i<37)||(i>=37&&i<39)||(i>=39&&i<42))
						document.getElementById("tabelas").innerHTML+="<div class ='col-md-offset-1'><input type='checkbox' name='tabs' value='"+i+"'> "+tabsvalues[i]+" </div>";
						else document.getElementById("tabelas").innerHTML+="<div class ='col-md-offset-0'><input type='checkbox' name='tabs' value='"+i+"'> "+tabsvalues[i]+" </div>";
						}
					}
				}
				 var values2 = [ "tipo","abertura","nome","fantasia","natureza_juridica",
                        "logradouro","numero","complemento","cep","bairro","municipio","uf","email","telefone",
                    "efr","situacao","data_situacao","motivo_situacao","situacao_especial","data_situacao_especial"];  
                        

                    	 var resumes = [ "TIPO:", "DATA DE ABERTURA:","NOME EMPRESARIAL:",
                    "TÍTULO DO ESTABELECIMENTO (NOME DE FANTASIA):","CÓDIGO E DESCRIÇÃO DA NATUREZA JURÍDICA:","LOGRADOURO:","NÚMERO:","COMPLEMENTO:","CEP:",
                    "BAIRRO/DISTRITO:","MUNICÍPIO:","UF:","ENDEREÇO ELETRÔNICO:","TELEFONE:","ENTE FEDERATIVO RESPONSÁVEL (EFR):","SITUAÇÃO CADASTRAL:",
                    "DATA DA SITUAÇÃO CADASTRAL:","MOTIVO DE SITUAÇÃO CADASTRAL:","SITUAÇÃO ESPECIAL:","DATA DA SITUAÇÃO ESPECIAL:" ];
                document.getElementById("ola").innerHTML="";
                   for(var i=0;i<values2.length;i++){
                  		
                    			if (i==4)
                    			{
                    				document.getElementById("ola").innerHTML+= `<div class='col-md-10'> <div class='form-group'> <h5> CÓDIGO E DESCRIÇÃO DA ATIVIDADE ELETRÔNICA PRINCIPAL:</h5>
								<input class='form-control' placeholder='CÓDIGO E DESCRIÇÃO DA ATIVIDADE ELETRÔNICA PRINCIPAL' id='atp' type='text' value='`+cnpjvalues[20]+`' > </div> </div> `;
									document.getElementById("ola").innerHTML+= `<div class='col-md-10'> <div class='form-group'> <h5> CÓDIGO E DESCRIÇÃO DAS ATIVIDADES ELETRÔNICAS SECUNDARIAS: </h5> <textarea name='ats'  class='form-control' id='ats' cols='60' rows='4' placeholder='CÓDIGO E DESCRIÇÃO DAS ATIVIDADES ELETRÔNICAS SECUNDARIAS:' required='required'>`+ cnpjvalues[21]+`</textarea> </div> </div>	`;	
                    			}
					   			document.getElementById("ola").innerHTML+= `<div class='col-md-10'> <div class='form-group'> <h5> `+resumes[i]+`</h5>
								<input class='form-control' placeholder='Info1' id='`+values2[i]+`' type='text' value='`+cnpjvalues[i]+`' > </div> </div> `;
					  			 }  
					  			 fezCnpj=true; 
							}

		



		function updatevalues()
		{
			//console.log("hey");
			var incomplet=false;
			if(fezCnpj){
			var ids=["cnpjj","name","cpf","ele","cep2","end","bairro2","cid","cap","tel","cel","email2","senha"];
			var values=new Array(ids.length);
			for (var i =0;i<ids.length;i++)
			{

				values[i]= document.getElementById(ids[i]).value!=""?document.getElementById(ids[i]).value:"---";
				if((i==0||i==1||i==ids.length-1)&&values[i]=="---")incomplet=true;
			}
			var cnpjinfo=""
			var classnpjinfo=""
			try{
			var valuescnpj = [ "tipo","abertura","nome","fantasia","natureza_juridica",
                        "logradouro","numero","complemento","cep","bairro","municipio","uf","email","telefone",
                    "efr","situacao","data_situacao","motivo_situacao","situacao_especial","data_situacao_especial"];  
			for (var i=0;i<valuescnpj.length+2;i++){
				if (i==valuescnpj.length)
					break;
				//console.log(valuescnpj[i]);
				classnpjinfo+=document.getElementById(valuescnpj[i]).value+"¬";
			}
			classnpjinfo+=document.getElementById("atp").value+"¬";
			classnpjinfo+=document.getElementById("ats").value;
		}
		catch(err){}
			var neg;
			for (var i=0;i<document.getElementsByName("neg").length;i++)
			{
				if (document.getElementsByName("neg")[i].checked)
				neg =i;
			}
			var tabels=[];
			for (var i=0;i<document.getElementsByName("tabs").length;i++)
			{
				if (document.getElementsByName("tabs")[i].checked)
				{
					tabels.push(i);
				}
			}
			var ready = document.getElementById("pront").checked?1:0;
			if (tabels.length==0)if(!confirm("Você não selecionou nenhuma tabela, deseja prosseguir?")){
				incomplet=true;
			}
			if(incomplet){alert("Você não selecionou os dados principais");}
			else {
				//console.log(values);
				//console.log(classnpjinfo);
				//console.log(classnpjinfo.split("¬"));
				//console.log(neg);
				console.log(ready);
				//console.log(tabels);
				ntab="";
				if(tabels.length==0){
					ntab="-";
				}
				else {
					for(var i=0;i<tabels.length;i++)
					{
						ntab+=tabels[i]+",";
					}
				}
				$.post('cadastro.php', { servID: 66 ,cnpj:values[0],infemp:classnpjinfo, nome:values[1],cpf:values[2],eletit:values[3],cep:values[4],end:values[5],bairro:values[6],cid:values[7],cap:values[8],tel:values[9],cel:values[10],email:values[11],pass:values[12],reg:neg,tabs:ntab,ready:ready}, function(data) {
					console.log(data);
					
					if (data=="OK")
					{
						alert("Sucesso na alteração do cadastro");
						window.location = window.location;

					}
					else 
					{
						alert("Erro no sistema");
					}
				});
			}			
			
		  }
		}



		function Editarbt() {
			document.getElementById("bestrow").innerHTML = "";
			var tmp= cadastrados.split('§');
			for(var i=0;i<tmp.length-1;i++){
				ShowEmpresas(tmp[i]);
							}

			document.getElementById("bestrow").innerHTML+="<div class='col-md-8 col-md-push-4 col-sm-4 col-sm-push-3 col-xs-12 col-xs-push-0' data-animate-effect='fadeIn'><button class='btn btn-primary' onclick='Cancel()'>Cancelar</button></div>";
		}
		function Cancel()
		{
			document.getElementById("bestrow").innerHTML = "";
			document.getElementById("bestrow").innerHTML = "<div class='col-md-8 col-md-push-3 col-sm-12 col-sm-push-0 col-xs-12 col-xs-push-0' data-animate-effect='fadeIn'> <div class='row'> <div class='col-md-5 text-center fh5co-heading animate-box' data-animate-effect='fadeIn'>  </div> <div class='col-md-11'> <h2>Selecione a ação</h2> <button class='btn btn-primary' onclick='Adcionarbt()'>Cadastrar empresa </button> <button class='btn btn-primary' id='editemp' onclick='Editarbt()' >Editar empresa</button> <button class='btn btn-primary' id='editpass' onclick='Editpass()' >Alterar Senha</button></div> </div> </div><div class='col-md-8 col-md-push-4 col-sm-12 col-sm-push-0 col-xs-12 col-xs-push-0' data-animate-effect='fadeIn'></div>";

		}
		function edit(cnpj)
		{
			$.post('cadastro.php', { servID: 54,cnpj:cnpj }, function(data) {
					console.log(data);
					if(data=="error"){
					alert("Erro no sistema");
					}
					else {
						editaropen(data);
					}
					});		
			
		}
		function exclui(cnpj)
		{
			if(confirm("Você tem certeza que deseja excluir  ?"))
			{
				$.post('cadastro.php', { servID: 11,cnpj:cnpj }, function(data) {
					console.log(data);
					if(data=="excluido"){
					alert("Excluido com sucesso");
					window.location = window.location;}

					else alert("Erro no sistema");
				});
			}
		}
	
		function validarCNPJ(cnpj) {
 
    cnpj = cnpj.replace(/[^\d]+/g,'');
 
    if(cnpj == '') return false;
     
    if (cnpj.length != 14)
        return false;
 
    // Elimina CNPJs invalidos conhecidos
    if (cnpj == "00000000000000" || 
        cnpj == "11111111111111" || 
        cnpj == "22222222222222" || 
        cnpj == "33333333333333" || 
        cnpj == "44444444444444" || 
        cnpj == "55555555555555" || 
        cnpj == "66666666666666" || 
        cnpj == "77777777777777" || 
        cnpj == "88888888888888" || 
        cnpj == "99999999999999")
        return false;
         
    // Valida DVs
    tamanho = cnpj.length - 2
    numeros = cnpj.substring(0,tamanho);
    digitos = cnpj.substring(tamanho);
    soma = 0;
    pos = tamanho - 7;
    for (i = tamanho; i >= 1; i--) {
      soma += numeros.charAt(tamanho - i) * pos--;
      if (pos < 2)
            pos = 9;
    }
    resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
    if (resultado != digitos.charAt(0))
        return false;
         
    tamanho = tamanho + 1;
    numeros = cnpj.substring(0,tamanho);
    soma = 0;
    pos = tamanho - 7;
    for (i = tamanho; i >= 1; i--) {
      soma += numeros.charAt(tamanho - i) * pos--;
      if (pos < 2)
            pos = 9;
    }
    resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
    if (resultado != digitos.charAt(1))
          return false;
           
    return true;
    
}
	
   

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

