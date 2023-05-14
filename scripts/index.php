<?php


$servername = "localhost";
$username = "root";
$password = "";
$dbname = "film";

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);

// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}

$json =  file_get_contents('./data.json');

$data = json_decode($json, true);
var_dump(count($data));
$i = 0;
foreach ($data as $film) {
    // insert into films
    $i++;
    $sql = "INSERT INTO films (titre, annee, note, duree) VALUES (?,?,?,?)";
    $stmt = $conn->prepare($sql);
    $stmt->bind_param('ssdi', $film['titre'], $film['annee'], $film['note'], $film['dure']);
    $stmt->execute();
    $film_id = $conn->insert_id;

    // insert into realisateurs
    foreach ($film['realisateurs'] as $realisateur) {
        $sql = "INSERT INTO realisateurs (nom) VALUES (?)";
        $stmt = $conn->prepare($sql);
        $stmt->bind_param('s', $realisateur);
        $stmt->execute();
        $realisateur_id = $conn->insert_id;

        // insert into film_realisateurs
        $sql = "INSERT INTO film_realisateurs (film_id, realisateur_id) VALUES (?, ?)";
        $stmt = $conn->prepare($sql);
        $stmt->bind_param('ii', $film_id, $realisateur_id);
        $stmt->execute();
    }

    // insert into acteurs and film_acteurs
    foreach ($film['acteurs'] as $acteur) {
        $sql = "INSERT INTO acteurs (nom) VALUES (?)";
        $stmt = $conn->prepare($sql);
        $stmt->bind_param('s', $acteur);
        $stmt->execute();
        $cast_actor_id = $conn->insert_id;

        $sql = "INSERT INTO film_acteurs (film_id, cast_actor_id) VALUES (?, ?)";
        $stmt = $conn->prepare($sql);
        $stmt->bind_param('ii', $film_id, $cast_actor_id);
        $stmt->execute();
    }

    // insert into genres and film_genres
    foreach ($film['genres'] as $genre) {
        // check if genre already exists
        $sql = "SELECT genre_id FROM genres WHERE genre = ?";
        $stmt = $conn->prepare($sql);
        $stmt->bind_param('s', $genre);
        $stmt->execute();
        $result = $stmt->get_result();
        if ($result->num_rows > 0) {
            // genre exists, get the genre_id
            $row = $result->fetch_assoc();
            $genre_id = $row['genre_id'];
        } else {
            // genre doesn't exist, insert it
            $sql = "INSERT INTO genres (genre) VALUES (?)";
            $stmt = $conn->prepare($sql);
            $stmt->bind_param('s', $genre);
            $stmt->execute();
            $genre_id = $conn->insert_id;
        }

        // insert into film_genres
        $sql = "INSERT INTO film_genres (film_id, genre_id) VALUES (?, ?)";
        $stmt = $conn->prepare($sql);
        $stmt->bind_param('ii', $film_id, $genre_id);
        $stmt->execute();
    }
    echo $i + '<br>';
}

$conn->close();
