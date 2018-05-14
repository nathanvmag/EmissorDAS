<?php
use PHPMailer\PHPMailer\PHPMailer;
use PHPMailer\PHPMailer\Exception;

require 'PHPMailer/src/Exception.php';
require 'PHPMailer/src/PHPMailer.php';
require 'PHPMailer/src/SMTP.php';
require 'configs.php';


if (isset($_POST['servID']))
{
	$servID= $_POST['servID'];
	if($servID=="392"||$servID=="939")
	{
		if(isset($_POST['cnpj'])&&isset($_POST['name'])&&isset($_POST['serv']))
		{
			$subject="";
			$txt="";
			if($servID=="392"){
			$txt = "<p>O usuário: ".$_POST['name']."<br></p>"."<p>Com cnpj: ".$_POST['cnpj']."<br></p>" .
			"<p>Solicitou o serviço de: ".$_POST['serv']."<br></p>";
			$subject = "Solicitação de serviço";
			}
			else{ $txt= "<p>O usuário: ".$_POST['name']."<br></p>"."<p>Com cnpj: ".$_POST['cnpj']."<br></p>" .
			"<p>Solicitou a ajuda com : ".$_POST['serv']."<br></p>";
			$subject = "Solicitação de ajuda";
		}
			$toemail= "";
			$connect = new mysqli(SERVERNAME,USERNAME,DBPASS,DBNAME);
			mysqli_set_charset($connect,"utf8") or die(mysqli_error($connect));
			$sql2 = "SELECT  `email` FROM `adm` WHERE 1";
			$result = mysqli_query($connect, $sql2) or die(mysqli_error($connect)); 
			 if(mysqli_num_rows($result) > 0)
				{
					while($row = mysqli_fetch_assoc($result))
					{
						$toemail= $row['email'];
					}
				}
				else echo "error";

			$mail = new PHPMailer;
			$mail->CharSet = 'UTF-8';
			//Enable SMTP debugging. 
			//$mail->SMTPDebug = 3;                               
			//Set PHPMailer to use SMTP.
			$mail->isSMTP();            
			//Set SMTP host name                          
			$mail->Host = "smtp.gmail.com";
			//Set this to true if SMTP host requires authentication to send email
			$mail->SMTPAuth = true;                          
			//Provide username and password     
			$mail->Username = "emissordas@gmail.com";                 
			$mail->Password = "emissordas22";                           
			//If SMTP requires TLS encryption then set it
			$mail->SMTPSecure = "tls";                           
			//Set TCP port to connect to 
			$mail->Port = 587;                                   

			$mail->From = "emissordas@gmail.com";
			$mail->FromName = "EmissorDas";

			$mail->addAddress($toemail, "Destinatário");

			$mail->isHTML(true);

			$mail->Subject = $subject;
			$mail->MsgHTML($txt);

			if(!$mail->send()) 
			{
			    echo "Mailer Error: " . $mail->ErrorInfo;
			} 
			else 
			{
			   echo "OK";


			 

			}
		}
		else echo "error";
	}
	else if ($servID==20)
	{
		if (isset($_POST['mes'])&&isset($_POST['cnpj']))
		{
			$cnpj=$_POST['cnpj'];			
			$mes=$_POST['mes'];
			$boleto="";
			$email="";
			$connect = new mysqli(SERVERNAME,USERNAME,DBPASS,DBNAME);
			mysqli_set_charset($connect,"utf8") or die(mysqli_error($connect));
			$sql2 = "SELECT `boleto` FROM `emissoes` WHERE  `cnpj`='$cnpj' AND `mes`= '$mes'";
			$result = mysqli_query($connect, $sql2) or die(mysqli_error($connect)); 
			 if(mysqli_num_rows($result) > 0)
				{
					while($row = mysqli_fetch_assoc($result))
					{
						$boleto= $row['boleto'];
					}
				}
				else echo "error";
			if($boleto!=""){
			$sql2= "SELECT `email` FROM `regusuarios` WHERE `cnpj`='$cnpj' ";
			$result = mysqli_query($connect, $sql2) or die(mysqli_error($connect)); 
			 if(mysqli_num_rows($result) > 0)
				{
					while($row = mysqli_fetch_assoc($result))
					{
						$email= $row['email'];
					}
				}else echo "error";
			$boleto= str_replace("/Site/", "", $boleto);
			$subject = "Segue o boleto do mês ".$_POST['mes'];
			$txt= "<h3>O boleto gerado segue em anexo:</h3> ";
			$mail = new PHPMailer;
			$mail->CharSet = 'UTF-8';
			//Enable SMTP debugging. 
			//$mail->SMTPDebug = 3;                               
			//Set PHPMailer to use SMTP.
			$mail->isSMTP();            
			//Set SMTP host name                          
			$mail->Host = "smtp.gmail.com";
			//Set this to true if SMTP host requires authentication to send email
			$mail->SMTPAuth = true;                          
			//Provide username and password     
			$mail->Username = "emissordas@gmail.com";                 
			$mail->Password = "emissordas22";                           
			//If SMTP requires TLS encryption then set it
			$mail->SMTPSecure = "tls";                           
			//Set TCP port to connect to 
			$mail->Port = 587;                                   

			$mail->From = "emissordas@gmail.com";
			$mail->FromName = "EmissorDas";

			$mail->addAddress($email, "Destinatário");
			$mail->addAttachment($boleto, 'boleto.pdf');

			$mail->isHTML(true);

			$mail->Subject = $subject;
			$mail->MsgHTML($txt);

			if(!$mail->send()) 
			{
			    echo "Mailer Error: " . $mail->ErrorInfo;
			} 
			else 
			{
				echo "email para ".$email."  ".$boleto;
				echo "OK";
				$connect = new mysqli(SERVERNAME,USERNAME,DBPASS,DBNAME);
				mysqli_set_charset($connect,"utf8") or die(mysqli_error($connect));
				$sql2 = "SELECT  `email` FROM `adm` WHERE 1";
				$result = mysqli_query($connect, $sql2) or die(mysqli_error($connect)); 
				 if(mysqli_num_rows($result) > 0)
					{
						while($row = mysqli_fetch_assoc($result))
						{
							$toemail= $row['email'];
						}
					}
				
				$mail->addAddress($toemail, "Destinatário");
			   	$txt.="<p> 2ª via para administrador do cnpj : ".$cnpj."</p>";
				$mail->isHTML(true);

				$mail->Subject = "2 via para Destinatário";
				$mail->MsgHTML($txt);
				if(!$mail->send())
				{
				 echo "Mailer Error: " . $mail->ErrorInfo;

				}else "2 via sucess";
			}

			}
			else echo "error";

		}
	}else if ($servID==103)
	{

		if (isset($_POST['cnpj']))
		{
			$cnpj= $_POST['cnpj'];

			$pass="";
			$email="";
			$connect = new mysqli(SERVERNAME,USERNAME,DBPASS,DBNAME);
			mysqli_set_charset($connect,"utf8") or die(mysqli_error($connect));
			$sql2 = "SELECT  `email`, `pass` FROM `regusuarios` WHERE `cnpj`='$cnpj'";
			$result = mysqli_query($connect, $sql2) or die(mysqli_error($connect)); 
            if(mysqli_num_rows($result) > 0)
				{
					while($row = mysqli_fetch_assoc($result))
					{
						$pass= $row['pass'];
						$email= $row['email'];	
					}
					
					$mail = new PHPMailer;
					$txt = "<p> Você solicitou esqueceu sua senha </p><br><p>Seu cnpj é :".$cnpj."</p><br><p>Sua senha é :".$pass." </p>";
					$mail->CharSet = 'UTF-8';
					//Enable SMTP debugging. 
					//$mail->SMTPDebug = 3;                               
					//Set PHPMailer to use SMTP.
					$mail->isSMTP();            
					//Set SMTP host name                          
					$mail->Host = "smtp.gmail.com";
					//Set this to true if SMTP host requires authentication to send email
					$mail->SMTPAuth = true;                          
					//Provide username and password     
					$mail->Username = "emissordas@gmail.com";                 
					$mail->Password = "emissordas22";                           
					//If SMTP requires TLS encryption then set it
					$mail->SMTPSecure = "tls";                           
					//Set TCP port to connect to 
					$mail->Port = 587;                                   

					$mail->From = "emissordas@gmail.com";
					$mail->FromName = "EmissorDas";

					$mail->addAddress($email, "Destinatário");

					$mail->isHTML(true);

					$mail->Subject = "Ajuda: esqueceu sua senha";
					$mail->MsgHTML($txt);

					if(!$mail->send()) 
					{
					    echo "Mailer Error: " . $mail->ErrorInfo;
					} 
					else 
					{
						echo "OK";
					}


				}
				else echo "error";

		}
	}
	else echo "error";
}  
?>