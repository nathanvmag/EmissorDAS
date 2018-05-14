<?php
	require 'configs.php';
	if(isset($_POST['servID'])){
		$servID= $_POST['servID'];
		if($servID==39)
		{
			if(isset($_POST['cnpj'])&&isset($_POST['infemp'])&&isset($_POST['nome'])&&isset($_POST['cpf'])&&isset($_POST['eletit'])&&isset($_POST['cep'])&&isset($_POST['end'])&&isset($_POST['bairro'])&&isset($_POST['cid'])&&isset($_POST['cap'])&&isset($_POST['tel'])&&isset($_POST['cel'])&&isset($_POST['email'])&&isset($_POST['reg'])&&isset($_POST['tabs'])&&isset($_POST['ready'])&&isset($_POST['pass']))
			{
				$cnpj= $_POST['cnpj'];
				$infemp= $_POST['infemp'];
				$nome=$_POST['nome'];
				$cpf=$_POST['cpf'];
				$eletit=$_POST['eletit'];
				$cep=$_POST['cep'];
				$end=$_POST['end'];
				$bairro=$_POST['bairro'];
				$cid=$_POST['cid'];
				$cap=$_POST['cap'];
				$tel=$_POST['tel'];
				$cel=$_POST['cel'];
				$email=$_POST['email'];
				$reg=$_POST['reg'];
				$tabs=$_POST['tabs'];
				$ready=$_POST['ready'];
				$pass=$_POST['pass'];
				$temp= $cnpj;
			    $connect = new mysqli(SERVERNAME,USERNAME,DBPASS,DBNAME);
			    mysqli_set_charset($connect,"utf8") or die(mysqli_error($connect));
			     $sql2 = "SELECT `cnpj` FROM `regusuarios` WHERE `cnpj`=$cnpj";
				 $result = mysqli_query($connect, $sql2) or die(mysqli_error($connect));    
				        if(mysqli_num_rows($result) == 0)
						{							
						    $sql = "INSERT INTO `regusuarios`( `cnpj`, `infemp`, `nome`, `cpf`, `eletit`, `cep`, `end`, `bairro`, `cid`, `cap`, `tel`, `cel`, `email`, `reg`, `tabs`, `ready`, `pass`) VALUES ('$cnpj','$infemp','$nome','$cpf','$eletit','$cep','$end','$bairro','$cid','$cap','$tel','$cel','$email','$reg','$tabs','$ready','$pass')";
						    mysqli_query($connect, $sql) or die(mysqli_error($connect));  
						    
						    echo "OK";  
						}
						else echo "CNPJerror";	  
				
				mysqli_close($connect);
			}
			
			else echo "error";
		}
		else if($servID==66)
		{
			if(isset($_POST['cnpj'])&&isset($_POST['infemp'])&&isset($_POST['nome'])&&isset($_POST['cpf'])&&isset($_POST['eletit'])&&isset($_POST['cep'])&&isset($_POST['end'])&&isset($_POST['bairro'])&&isset($_POST['cid'])&&isset($_POST['cap'])&&isset($_POST['tel'])&&isset($_POST['cel'])&&isset($_POST['email'])&&isset($_POST['reg'])&&isset($_POST['tabs'])&&isset($_POST['ready'])&&isset($_POST['pass']))
			{
				$cnpj= $_POST['cnpj'];
				$infemp= $_POST['infemp'];
				$nome=$_POST['nome'];
				$cpf=$_POST['cpf'];
				$eletit=$_POST['eletit'];
				$cep=$_POST['cep'];
				$end=$_POST['end'];
				$bairro=$_POST['bairro'];
				$cid=$_POST['cid'];
				$cap=$_POST['cap'];
				$tel=$_POST['tel'];
				$cel=$_POST['cel'];
				$email=$_POST['email'];
				$reg=$_POST['reg'];
				$tabs=$_POST['tabs'];
				$ready=$_POST['ready'];
				$pass=$_POST['pass'];
				
			    $connect = new mysqli(SERVERNAME,USERNAME,DBPASS,DBNAME);
			    mysqli_set_charset($connect,"utf8") or die(mysqli_error($connect));
			    $sql = "UPDATE `regusuarios` SET `infemp`='$infemp',`nome`='$nome',`cpf`='$cpf',`eletit`='$eletit',`cep`='$cep',`end`='$end',`bairro`='$bairro',`cid`='$cid',`cap`='$cap',`tel`='$tel',`cel`='$cel',`email`='$email',`reg`='$reg',`tabs`='$tabs',`ready`='$ready',`pass`='$pass' WHERE `cnpj`='$cnpj'";
			    echo "OK";
				mysqli_query($connect, $sql) or die(mysqli_error($connect));    
			}
			else echo "error";
		}
		else if($servID==11)
			{
				if(isset($_POST['cnpj'])){
				$cnpj=$_POST['cnpj'];
				$connect = new mysqli(SERVERNAME,USERNAME,DBPASS,DBNAME);
			    mysqli_set_charset($connect,"utf8") or die(mysqli_error($connect));
			    $sql2 = "DELETE FROM `regusuarios` WHERE `cnpj`='$cnpj'";
				mysqli_query($connect, $sql2) or die(mysqli_error($connect));    
				$sql2 = "DELETE FROM `emissoes` WHERE `cnpj`='$cnpj'";
				mysqli_query($connect, $sql2) or die(mysqli_error($connect)); 
				echo "excluido";
					}
				else echo "erro";
				
			}
			else if($servID==54)
			{
				if(isset($_POST['cnpj'])){
					$cnpj=$_POST['cnpj'];
					$connect = new mysqli(SERVERNAME,USERNAME,DBPASS,DBNAME);
				    mysqli_set_charset($connect,"utf8") or die(mysqli_error($connect));
				    $sql2 = "SELECT `cnpj`, `infemp`, `nome`, `cpf`, `eletit`, `cep`, `end`, `bairro`, `cid`, `cap`, `tel`, `cel`, `email`, `reg`, `tabs`, `ready`, `pass` FROM `regusuarios` WHERE `cnpj`='$cnpj'";

					$result =mysqli_query($connect, $sql2) or die(mysqli_error($connect)); 
					if(mysqli_num_rows($result) > 0)
					{
						while($row = mysqli_fetch_assoc($result))
						{
							echo $row['cnpj']."|".$row['infemp']."|".$row['nome']."|".$row['cpf']."|".$row['eletit']."|".$row['cep']."|".$row['end']."|".$row['bairro']."|".$row['cid']."|".$row['cap']."|".$row['tel']."|".$row['cel']."|".$row['email']."|".$row['reg']."|".$row['tabs']."|".$row['ready']."|".$row['pass'];
						}
					}else echo "error";
				}
				else echo "erro";
				
			}

		else if($servID==98)
		{
				$connect = new mysqli(SERVERNAME,USERNAME,DBPASS,DBNAME);
			    mysqli_set_charset($connect,"utf8") or die(mysqli_error($connect));
			    $sql2 = "SELECT  `cnpj`, `nome`, `cpf` FROM `regusuarios` WHERE 1";
				$result = mysqli_query($connect, $sql2) or die(mysqli_error($connect));    
				    if(mysqli_num_rows($result) > 0)
					{
						while($row = mysqli_fetch_assoc($result))
						{
							echo $row['cnpj']."|".$row['nome']."|".$row['cpf']."§";
						}
					}else echo "-";
				
		}
		else echo "error";
	}
	else echo "error";

	
  ?>