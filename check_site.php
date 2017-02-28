<?php


//This needs to be changed to your own details
$servername = "localhost:3306";
$username = "desarrollo";
$password = "eLuv326!";
$dbname = "phishingFisher";

// Create <connection></connection>
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
} 


$url = isset($_GET['site']) ? $_GET['site'] : null;
preg_match('/^(?:https?:\/\/)?(?:[^@\/\n]+@)?(?:www\.)?([^:\/\n]+)/', $url, $matches);
$url = $matches[0];

$sql = "SELECT DANGER FROM all_sites WHERE URL LIKE '%" . $url . "%' LIMIT 1";
$result = $conn->query($sql);   

if ($result->num_rows > 0) {
    // output data of each row
    while($row = $result->fetch_assoc()) {
        echo $row["DANGER"];
    }
} else {
    echo "3";   
}

$conn->close();
?>