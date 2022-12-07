<?php
require 'ConnectionSettings.php';

//variables submited by user
$loginUserID = $_POST["loginUserID"];
$loginfbname = $_POST["loginfbname"];

if($conn->connect_error){
    die("Connection failed: ".$conn->connect_error);
}

$sql = "SELECT userid FROM accounts WHERE userid = '" . $loginUserID . "'";

$result = $conn->query($sql);

if ($result->num_rows > 0) {
  //Tell user that name is already taken
  echo "UserID is already taken.";

} else {
  echo "Creating user...";
  //Insert user into database
  $sql2 = "INSERT INTO accounts (userid,fbname,coins,cash) VALUES('" . $loginUserID . "','" . $loginfbname . "',0,0)";
  if($conn->query($sql2)===TRUE){
    echo "New record created successfully";
  } else{
    echo "Error: ".$sql2."<br>".$conn->error;
  }
}
$conn->close();

?>