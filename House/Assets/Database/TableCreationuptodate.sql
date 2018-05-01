	/*GAMETABLE*/

CREATE TABLE GameTable (
    gameNo    INTEGER PRIMARY KEY AUTOINCREMENT,
    time_     TIME DEFAULT CURRENT_TIMESTAMP,
    trading   BOOLEAN CHECK (trading IN (0, 1) ) NOT NULL
);

	/*DEV PROPERTIES*/

CREATE TABLE DevProperties (
    tileNo INTEGER NOT NULL,
    prop_name VARCHAR (50),
    group_ VARCHAR (15),
    cost INTEGER NOT NULL,
    undeveloped_rent INTEGER NOT NULL,
    undeveloped_rentAll INTEGER NOT NULL,
    rent_1 INTEGER NOT NULL,
    rent_2 INTEGER NOT NULL,
    rent_3 INTEGER NOT NULL,
    rent_4 INTEGER NOT NULL,
    rent_5 INTEGER NOT NULL,
    PRIMARY KEY 
        (tileNo)
    );

	/*STATIONS*/

CREATE TABLE Stations (
    tileNo   INTEGER,
    prop_name VARCHAR(50),
    group_ VARCHAR (15) NOT NULL DEFAULT "Stations",
    cost INTEGER NOT NULL DEFAULT 200,
    rent1_St INTEGER NOT NULL DEFAULT 25,
    rent2_St INTEGER NOT NULL DEFAULT 50,
    rent3_St INTEGER NOT NULL DEFAULT 100,
    rent4_St INTEGER NOT NULL DEFAULT 200,
    PRIMARY KEY 
        (tileNo)
    );

	/*UTILITIES*/


CREATE TABLE Utilities (
    tileNo INTEGER,
    prop_name VARCHAR(50),
    group_ VARCHAR(50) NOT NULL DEFAULT "Utilities",
    cost INTEGER,
    rent1_Ut INTEGER DEFAULT 4,
    rent2_Ut INTEGER DEFAULT 10,
    PRIMARY KEY 
        (tileNo)  
);

CREATE TABLE NonProperties (
    tileNo INTEGER,
    prop_name VARCHAR(50),
    group_ VARCHAR(50),
    cost INTEGER,
    PRIMARY KEY 
        (tileNo)
    );

	/*PLAYER*/

/* Free parking as player????*/

CREATE TABLE Players (
    player_id VARCHAR(50),
    gameNo INTEGER,
    token_loc INTEGER,
    token_shape VARCHAR(50),
    wallet INTEGER(50),  /* set intial amount of money in settings */
    get_out_of_jail_card INTEGER(50),
    bot BOOLEAN,
    jail BOOLEAN,
    player_name VARCHAR(50),
    PRIMARY KEY (
        player_id, gameNo
    ),
    FOREIGN KEY (
        gameNo
    )
    REFERENCES GameTable (gameNo)
);

		/*ACCOUNT*/


CREATE TABLE Account (
    player_id VARCHAR(50),
    password_ VARCHAR (50),
    PRIMARY KEY (
        player_id
    )
);


    /*DEV ASSETS*/

CREATE TABLE devAssets (
    assetNo   INTEGER,
    developed INTEGER,
    player_id INTEGER,
    gameNo INTEGER,
    mortgaged BOOLEAN,
    FOREIGN KEY (
        assetNo
    )
    REFERENCES DevProperties (tileNo),
    FOREIGN KEY (
        player_id
    )
    REFERENCES Players (player_id),
    FOREIGN KEY (
        gameNo
    )
    REFERENCES GameTable (gameNo) 
);

    /*NON DEV ASSETS*/

CREATE TABLE UtilitiesAssets (
    assetNo INTEGER,
    type VARCHAR(50),
    player_id INTEGER,
    gameNo INTEGER,
    mortgaged BOOLEAN,
    FOREIGN KEY (
        assetNo
    )
    REFERENCES Utilities (tileNo),
    FOREIGN KEY (
        player_id
    )
    REFERENCES Players (player_id),
    FOREIGN KEY (
        gameNo
    )
    REFERENCES GameTable (gameNo)   
);

CREATE TABLE StationAssets (
    assetNo INTEGER,
    type VARCHAR(50),
    player_id INTEGER,
    gameNo INTEGER,
    mortgaged BOOLEAN,
    FOREIGN KEY (
        assetNo
    )
    REFERENCES Stations (tileNo),
    FOREIGN KEY (
        player_id
    )
    REFERENCES Players (player_id),
    FOREIGN KEY (
        gameNo
    )
    REFERENCES GameTable (gameNo)
    );

CREATE TABLE OpportunityKnocks (
    cardNo INTEGER,
    description VARCHAR(255), /*card description*/
    category VARCHAR(50), /*type of action*/
    cost INTEGER, /*cost if there is one, else 0*/
    moves INTEGER, /*how far needs to move, else 0 (will need to calculate if passes go)*/
    moveToLocation INTEGER, /*the tileNo to move to else NULL (will need to calculate if passes go)*/
    receiver VARCHAR(50), /*the receiver of the payment else NULL*/
    houseCost INTEGER, /*for repairs, else null*/
    hotelCost INTEGER /*for repairs, else null*/
    );

CREATE TABLE PotLuck (
    cardNo INTEGER,
    description VARCHAR(255), /*card description*/
    category VARCHAR(50), /*type of action*/
    cost INTEGER, /*cost if there is one, else 0*/
    moveToLocation INTEGER, /*the tileNo to move to else NULL (will need to calculate if passes go)*/
    receiver VARCHAR(50) /*the receiver of the payment else NULL*/
    );

