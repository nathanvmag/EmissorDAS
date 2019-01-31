<?php  
require 'configs.php';
if(isset($_POST['servID']))
{
	$servID= $_POST['servID'];
	if($servID==3092)
	{
		if(isset($_POST['pass']))
		{
			$pass = $_POST['pass'];
			$pass= md5($pass);
			$connect = new mysqli(SERVERNAME,USERNAME,DBPASS,DBNAME);
			mysqli_set_charset($connect,"utf8") or die(mysqli_error($connect));
			$sql2 = "SELECT `admpass` FROM `adm` WHERE `admpass` ='$pass'";
			$result = mysqli_query($connect, $sql2) or die(mysqli_error($connect));    
			    if(mysqli_num_rows($result) > 0)
			    {
			    	echo "OK";
			    }
			    else echo "error";
		}
		else echo "error";
	}
	else if($servID==593)
	{
		if(isset($_POST['login'])&&isset($_POST['pass']))
		{
			$login=$_POST['login'];
			$pass=$_POST['pass'];
			$connect = new mysqli(SERVERNAME,USERNAME,DBPASS,DBNAME);
			mysqli_set_charset($connect,"utf8") or die(mysqli_error($connect));
			$sql2 = "SELECT   `nome`,  `ready`, `pass` FROM `regusuarios` WHERE (`cnpj`='$login'  OR `email`='$login') AND `pass`= '$pass'";
			$result = mysqli_query($connect, $sql2) or die(mysqli_error($connect));    
			    if(mysqli_num_rows($result) > 0)
				{
					while($row = mysqli_fetch_assoc($result))
					{
						if($row['ready']=="0")echo "Nready";
						else if ($row['pass']=="123456")echo "changepass|".$row['nome'];
						else echo "S|".$row['nome'];

					}
				}else echo "N";
		}
	}
	else if($servID==606)
	{
		if(isset($_POST['login'])&&isset($_POST['pass']))
		{
			$login=$_POST['login'];
			$pass=$_POST['pass'];
			$connect = new mysqli(SERVERNAME,USERNAME,DBPASS,DBNAME);
			mysqli_set_charset($connect,"utf8") or die(mysqli_error($connect));
			$sql2 = "SELECT   `cnpj` FROM `regusuarios` WHERE (`cnpj`='$login'  OR `email`='$login') AND `pass`= '$pass'";
			$result = mysqli_query($connect, $sql2) or die(mysqli_error($connect));    
			    if(mysqli_num_rows($result) > 0)
				{
					while($row = mysqli_fetch_assoc($result))
					{
						echo $row['cnpj'];

					}
				}else echo "N";
		}
	}
	else if($servID==1102)
	{
		if(isset($_POST['pass1'])&&isset($_POST['pass']))
		{
			$pass1=$_POST['pass1'];
			$pass=$_POST['pass'];
			$pass = md5($pass);
			$pass1= md5($pass1);
			$connect = new mysqli(SERVERNAME,USERNAME,DBPASS,DBNAME);
			mysqli_set_charset($connect,"utf8") or die(mysqli_error($connect));
			$sql2 = "SELECT `admpass` FROM `adm` WHERE `admpass`='$pass'";
			$result = mysqli_query($connect, $sql2) or die(mysqli_error($connect));    
			    if(mysqli_num_rows($result) > 0)
				{
					$sql = "UPDATE `adm` SET `admpass`='$pass1'";
					$result2 = mysqli_query($connect, $sql) or die(mysqli_error($connect)); 	
					echo "OK";
				}
				else echo "N";
		}
		else echo "error";
	}
	else if($servID==3030)
	{
			$connect = new mysqli(SERVERNAME,USERNAME,DBPASS,DBNAME);
			mysqli_set_charset($connect,"utf8") or die(mysqli_error($connect));
			$sql2 = "SELECT `email` FROM `adm` WHERE 1";
			$result = mysqli_query($connect, $sql2) or die(mysqli_error($connect));    
			    if(mysqli_num_rows($result) > 0)
				{
					while($row = mysqli_fetch_assoc($result))
					{
						echo $row['email'];
					}
					
				}
				else echo "error";		
	}
	else if($servID==9021)
	{
		if(isset($_POST['email'])){
			$email =$_POST['email'];
			$connect = new mysqli(SERVERNAME,USERNAME,DBPASS,DBNAME);
			mysqli_set_charset($connect,"utf8") or die(mysqli_error($connect));
			$sql2 = "UPDATE `adm` SET `email`='$email' WHERE 1";
			$result = mysqli_query($connect, $sql2) or die(mysqli_error($connect));    
			echo "OK";
			}
			else echo "error";
	}
	else if ($servID==772)
	{
		if(isset($_POST['rvend'])&&isset($_POST['pserv'])&&isset($_POST['mes'])&&isset($_POST['cnpj'])&&isset($_POST['tt']))
		{
			$cnpj=$_POST['cnpj'];
			$rvend=$_POST['rvend'];
			$pserv=$_POST['pserv'];
			$mes=$_POST['mes'];
			$data=$_POST['tt'];
			if($data=="ask")
			{
				$connect = new mysqli(SERVERNAME,USERNAME,DBPASS,DBNAME);
				mysqli_set_charset($connect,"utf8") or die(mysqli_error($connect));
				$sql2 = "DELETE FROM `emissoes` WHERE `cnpj`='$cnpj' AND `mes`= '$mes'";
				$result = mysqli_query($connect, $sql2) or die(mysqli_error($connect)); 
				$mes2= $mes;
				if(intval($mes2)>9)$mes2=$mes2;
				else $mes2="0".$mes2;

				if(file_exists("das/".$cnpj."/".$mes2."/boleto.pdf"))unlink("das/".$cnpj."/".$mes2."/boleto.pdf");
				//echo "das/".$cnpj."/".$mes2."/boleto.pdf";
			}

			if(is_numeric($rvend)&&is_numeric($pserv)){
			$myfile = fopen("r/requests.txt", "a") or die("Unable to open file!");
			$txt = $cnpj."?".$pserv."?".$rvend."?".$mes."|";
			fwrite($myfile, "\n". $txt);
			fclose($myfile);
			echo "OK";
		}
			else echo "n";
		}
		else echo "error";
	}
	else if($servID==183)
	{
		if(isset($_POST['cnpj']))
		{
			$cnpj=$_POST['cnpj'];		

			$connect = new mysqli(SERVERNAME,USERNAME,DBPASS,DBNAME);
			mysqli_set_charset($connect,"utf8") or die(mysqli_error($connect));
			$sql2 = "SELECT  `mes`,`status`, `boleto`, `pago` FROM `emissoes` WHERE `cnpj`='$cnpj' ORDER BY(`mes`) DESC";
			$result=mysqli_query($connect, $sql2) or die(mysqli_error($connect)); 
			if(mysqli_num_rows($result) > 0)
				{
					while($row = mysqli_fetch_assoc($result))
					{
						echo $row['mes']."@".$row['status']."@".$row['boleto']."@".$row['pago']."|";
						
					}
					
				}
			else echo "error";
			
		}
		else echo "error";
	}
	else if ($servID==991)
	{
		echo "OLAA";
		if(isset($_POST['cnpj'])&&isset($_POST['mes'])&&isset($_POST['pago']))
		{
			$cnpj=$_POST['cnpj'];			
			$mes=$_POST['mes'];
			$pago=$_POST['pago'];
			$connect = new mysqli(SERVERNAME,USERNAME,DBPASS,DBNAME);
			mysqli_set_charset($connect,"utf8") or die(mysqli_error($connect));
			$sql2 = "UPDATE `emissoes` SET `pago`='$pago' WHERE `cnpj`='$cnpj' AND `mes`= '$mes'";
			mysqli_query($connect, $sql2) or die(mysqli_error($connect)); 
			echo "OK";
		}
		else echo "error";
	}
	else if ($servID==356)
	{
		if(isset($_POST['cnpj'])&&isset($_POST['mes']))
		{
			$cnpj=$_POST['cnpj'];			
			$mes=$_POST['mes'];

			$connect = new mysqli(SERVERNAME,USERNAME,DBPASS,DBNAME);
			mysqli_set_charset($connect,"utf8") or die(mysqli_error($connect));
			$sql2="";
			if (isset($_POST['tempfile']))
			{
				$sql2= "UPDATE `emissoes` SET `status`='Erro, mostrando boleto anterior',`boleto`='$tempfile' WHERE `cnpj`='$cnpj' AND `mes`= '$mes'";
			}
			else
			$sql2 = "UPDATE `emissoes` SET `status`='Erro, tente emitir novamente ou contate o corretor' WHERE `cnpj`='$cnpj' AND `mes`= '$mes'";
			mysqli_query($connect, $sql2) or die(mysqli_error($connect)); 
			$today = getdate();

			$myfile = fopen("log.txt", "a") or die("Unable to open file!");
			$txt = "Data de emissão: ".$today['mday']."/".$today['mon']."/".$today['year']." cnpj:".$cnpj."  Mês de emissão: ".$mes."  Erro, tente emitir novamente ou contate o corretor"."\r\n";
			fwrite($myfile, "\n". $txt);
			fclose($myfile);
			echo "OK";
		}
		else echo "error";
	}
	else if ($servID==230)
	{
		if(isset($_POST['mes'])&&isset($_POST['cnpj'])&&isset($_POST['boleto']))
		{
			$cnpj=$_POST['cnpj'];			
			$mes=$_POST['mes'];
			$boleto =$_POST['boleto'];
			$connect = new mysqli(SERVERNAME,USERNAME,DBPASS,DBNAME);
			mysqli_set_charset($connect,"utf8") or die(mysqli_error($connect));
			$sql2 = "UPDATE `emissoes` SET `status`='Aguardando Pagamento',`boleto`='$boleto'  WHERE `cnpj`='$cnpj' AND `mes`= '$mes'";
			mysqli_query($connect, $sql2) or die(mysqli_error($connect)); 
			$today = getdate();
			$myfile = fopen("log.txt", "a") or die("Unable to open file!");
			$txt = "Data de emissão: ".$today['mday']."/".$today['mon']."/".$today['year']." cnpj:".$cnpj."  Mês de emissão: ".$mes."  Emitido com sucesso"."\r\n";
			fwrite($myfile, "\n". $txt);
			fclose($myfile);
			echo "OK";
		}
		else echo "error";
	}
	else if ($servID=="3156")
	{
		if(isset($_POST['mes'])&&isset($_POST['cnpj']))
		{
			$cnpj=$_POST['cnpj'];			
			$mes=$_POST['mes'];
			$connect = new mysqli(SERVERNAME,USERNAME,DBPASS,DBNAME);
			mysqli_set_charset($connect,"utf8") or die(mysqli_error($connect));
			$sql2 = "SELECT `cnpj`, `mes`,  `pago` FROM `emissoes` WHERE `cnpj`='$cnpj' AND `mes`= '$mes'";
			$result = mysqli_query($connect, $sql2) or die(mysqli_error($connect));    
			    if(mysqli_num_rows($result) == 0)										
				echo "OK";
			else echo "ask";
		}
			else echo "error";
		
	}
	else if ($servID=="926")
	{
		if(isset($_POST['mes'])&&isset($_POST['cnpj']))
		{
			$cnpj=$_POST['cnpj'];			
			$mes=$_POST['mes'];
			$connect = new mysqli(SERVERNAME,USERNAME,DBPASS,DBNAME);
			mysqli_set_charset($connect,"utf8") or die(mysqli_error($connect));
			$sql2 = "SELECT  `pserv`, `rprod` FROM `emissoes` WHERE `cnpj`='$cnpj' AND `mes`= '$mes'";
			$result = mysqli_query($connect, $sql2) or die(mysqli_error($connect));    
			if(mysqli_num_rows($result) > 0)
				{
					while($row = mysqli_fetch_assoc($result))
					{
						echo $row['pserv']."@".$row['rprod'];
					}
				}				
				else echo "error";  
			
		}
			else echo "error";
		
	}
	else if ($servID==118)
	{
		if(isset($_POST['cnpj'])&&isset($_POST['sen']))
		{
			$cnpj=$_POST['cnpj'];
			$sen=$_POST['sen'];
			$connect = new mysqli(SERVERNAME,USERNAME,DBPASS,DBNAME);
			mysqli_set_charset($connect,"utf8") or die(mysqli_error($connect));
			$sql2 = "UPDATE `regusuarios` SET  `pass`='$sen' WHERE `cnpj`='$cnpj'";
			mysqli_query($connect, $sql2) or die(mysqli_error($connect));    
			echo "OK";

		}else echo "error";
	}
	else if ($servID==881)
	{
		if(isset($_POST['cnpj']))
		{
			$cnpj=$_POST['cnpj'];
			$connect = new mysqli(SERVERNAME,USERNAME,DBPASS,DBNAME);
			mysqli_set_charset($connect,"utf8") or die(mysqli_error($connect));
			$sql2 = "SELECT  `reg`,`tabs` FROM `regusuarios` WHERE cnpj='$cnpj'";
			$result = mysqli_query($connect, $sql2) or die(mysqli_error($connect));    
			    if(mysqli_num_rows($result) > 0)
				{
					while($row = mysqli_fetch_assoc($result))
					{
						echo $row['reg']."@".$row['tabs'];
					}
				}
				else echo "error";

		}
	}
	else if ($servID==912)
	{
		if(isset($_POST['cnpj'])&&isset($_POST['mes'])&&isset($_POST['pserv'])&&isset($_POST['rprod'])&&isset($_POST['status'])&&isset($_POST['pago']))
		{
			$cnpj= $_POST['cnpj'];
			$mes = $_POST['mes'];
			$pserv= $_POST['pserv'];
			$rprod= $_POST['rprod'];
			$status= $_POST['status'];
			$pago= $_POST['pago'];
			$connect = new mysqli(SERVERNAME,USERNAME,DBPASS,DBNAME);
			mysqli_set_charset($connect,"utf8") or die(mysqli_error($connect));
			$sql2 = "INSERT INTO `emissoes`(`cnpj`, `mes`, `pserv`, `rprod`, `status`, `pago`) VALUES ('$cnpj','$mes','$pserv','$rprod','$status','$pago')";
			mysqli_query($connect, $sql2) or die(mysqli_error($connect));    
			echo "OK";

		}else echo "error";
	}
	else echo "error";
}
else echo "Noservid";
?>