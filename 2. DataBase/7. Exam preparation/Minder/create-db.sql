SET default_storage_engine=InnoDB;

CREATE TABLE characteristics(
    characteristic_id INT PRIMARY KEY AUTO_INCREMENT,
    title VARCHAR(255) NOT NULL
);

CREATE TABLE users(
	user_id INT PRIMARY KEY AUTO_INCREMENT,
    username VARCHAR(50) NOT NULL,
    email VARCHAR(255) NOT NULL,
    password VARCHAR(255) NOT NULL,
    first_name VARCHAR(255) NOT NULL,
    last_name VARCHAR(255) NOT NULL,
    birthdate DATE NOT NULL,
    gender ENUM('m', 'f') NOT NULL,
    bio TEXT,
    latitude DOUBLE NOT NULL,
    longitude DOUBLE NOT NULL,
    profile_picture VARCHAR(50)
);

CREATE TABLE characteristics_users(
	characteristic_id INT,
    user_id INT,
    value VARCHAR(255) NOT NULL,
    CONSTRAINT pk_characteristics_users
    PRIMARY KEY (characteristic_id, user_id),
    CONSTRAINT fk_characteristics_users_characteristics
    FOREIGN KEY (characteristic_id) REFERENCES characteristics(characteristic_id),
    CONSTRAINT fk_characteristics_users_users
    FOREIGN KEY (user_id) REFERENCES users(user_id)
);

CREATE TABLE connections(
	connection_id INT PRIMARY KEY AUTO_INCREMENT,
    from_user_id INT NOT NULL,
    to_user_id INT NOT NULL,
	accepted BOOL NOT NULL DEFAULT (0),
    CONSTRAINT fk_connections_users_from_user
    FOREIGN KEY (from_user_id) REFERENCES users(user_id),
    CONSTRAINT fk_connections_users_to_user
    FOREIGN KEY (to_user_id) REFERENCES users(user_id)
);

CREATE TABLE likes(
	liked_by_user_id INT NOT NULL,
	liked_user_id INT NOT NULL,
    CONSTRAINT pk_likes
    PRIMARY KEY (liked_by_user_id, liked_user_id),
    CONSTRAINT fk_likes_users_liked_by_user
    FOREIGN KEY (liked_by_user_id) REFERENCES users(user_id),
    CONSTRAINT fk_likes_users_liked_user
    FOREIGN KEY (liked_user_id) REFERENCES users(user_id)
);