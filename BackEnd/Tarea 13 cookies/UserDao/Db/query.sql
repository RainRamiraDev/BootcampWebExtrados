-- AUXILIAR TABLES
CREATE TABLE T_SERIES(
	id_series INT PRIMARY KEY,
	series_name VARCHAR(30) NOT NULL,
	release_date DATETIME NOT NULL
);
GO
CREATE TABLE T_CARDS(
	id_card INT PRIMARY KEY,
	illustration VARCHAR(30) NOT NULL,
	attack INT,
	deffense INT
);
GO
CREATE TABLE T_COUNTRIES(
	id_country INT PRIMARY KEY,
	country_name VARCHAR(30)
);
GO
CREATE TABLE T_ROLES(
	id_rol INT PRIMARY KEY,
	rol VARCHAR(20)
);
GO

-- MAIN TABLES

CREATE TABLE T_USERS(
	id_user INT PRIMARY KEY,
	id_country INT,
	id_rol INT,
	fullname VARCHAR(50),
	alias VARCHAR(20),
	email VARCHAR(30),
	games_won INT,
	games_lost INT,
	discualifications INT,
	avatar_url VARCHAR(255),
	passcode VARCHAR(10)
CONSTRAINT fk_country_user FOREIGN KEY (id_country) REFERENCES T_COUNTRIES (id_country), 
CONSTRAINT fk_rol_user FOREIGN KEY (id_rol) REFERENCES T_ROLES (id_rol)
);
GO
CREATE TABLE T_REFRESH_TOKENS(
	id_token INT PRIMARY KEY,
	id_user INT,
	token VARCHAR(255) NOT NULL UNIQUE,
	expiry_date DATETIME NOT NULL,
   created_at DATETIME DEFAULT CURRENT_TIMESTAMP
CONSTRAINT fk_user_token FOREIGN KEY (id_user) REFERENCES T_USERS (id_user) 
);
GO
CREATE TABLE T_CARD_SERIES(
	id_card_series INT PRIMARY KEY,
	id_card INT,
	id_series INT 
CONSTRAINT fk_card_cseries FOREIGN KEY (id_card) REFERENCES T_CARDS (id_card),
CONSTRAINT fk_series_cseries FOREIGN KEY (id_series) REFERENCES T_CARDS (id_series)
);

CREATE TABLE T_TOURNAMENTS(
	id_tourn INT PRIMARY KEY,
	id_country INT,
	id_organizer INT,
	start_datetime DATETIME,
	end_datetime DATETIME,
	current_phase VARCHAR(10)
CONSTRAINT fk_tourn_country FOREIGN KEY (id_country) REFERENCES T_COUNTRIES (id_country),
CONSTRAINT fk_tourn_organizer FOREIGN KEY (id_organizer) REFERENCES T_USERS (id_organizer)
);

CREATE TABLE T_ROUNDS(
	id_round INT PRIMARY KEY,
	id_player1 INT,
	id_player2 INT,
	id_winner INT,
	round_number INT
CONSTRAINT fk_round_p1 FOREIGN KEY (id_player1) REFERENCES T_USERS (id_user),
CONSTRAINT fk_round_p2 FOREIGN KEY (id_player2) REFERENCES T_USERS (id_user),
CONSTRAINT fk_round_winner FOREIGN KEY (id_winner) REFERENCES T_USERS (id_user)
);

CREATE TABLE T_GAMES(
	id_game INT PRIMARY KEY,
	id_round INT,
	id_tournament INT,
	start_datetime DATETIME
CONSTRAINT fk_game_round FOREIGN KEY (id_round) REFERENCES T_ROUNDS (id_round),
CONSTRAINT fk_game_tournament FOREIGN KEY (id_tournament) REFERENCES T_TOURNAMENTS (id_tournament)

);


-- TRANSACCIONAL TABLES

CREATE TABLE T_TOURN_JUDGES(
	id_tourn_judges INT PRIMARY KEY,
	id_tournament INT,
	id_judge INT
CONSTRAINT fk_tourn_judges_tourn FOREIGN KEY (id_tournament) REFERENCES T_TOURNAMENTS (id_tournament),
CONSTRAINT fk_tourn_judges_judge FOREIGN KEY (id_judge) REFERENCES T_JUDGES (id_judge)
);


CREATE TABLE T_TOURN_SERIES(

);


CREATE TABLE T_TOURN_PLAYERS(

);


CREATE TABLE T_TOURN_DISQUALIFICATIONS(

);

CREATE TABLE T_TOURN_DECKS(

);


