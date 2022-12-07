<?php
require 'ConnectionSettings.php';

//variables submited by user
$loginUserID = $_POST["loginUserID"];

if($conn->connect_error){
    die("Connection failed: ".$conn->connect_error);
}

$sql = "SELECT userid FROM accounts WHERE userid = '" . $loginUserID . "'";

$result = $conn->query($sql);

if ($result->num_rows > 0) {
  // output data of each row
  while($row = $result->fetch_assoc()) {
    if($row["userid"] == $loginUserID){
        echo $row["userid"];
        //Get user data

        //Get player info

        //Get Inventory

        //Modify player data

        //Update inventory

    }
    else{
        echo "Wrong Credentials.";
    }
  }
} else {
  echo "UserID does not exists";
}
$conn->close();

?>