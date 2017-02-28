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
echo $url;

//$sql = "SELECT DANGER FROM all_sites WHERE URL=" . $url . " LIMIT 1";
$sql = "SELECT * FROM all_sites";
$result = $conn->query($sql);
echo $result;

if ($result->num_rows > 0) {
    // output data of each row
    while($row = $result->fetch_assoc()) {
        echo "id: " . $row["id"]."<br>";
    }
} else {
    echo "0 results";   
}

$conn->close();
?>