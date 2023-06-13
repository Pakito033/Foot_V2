CREATE SEQUENCE player_id_seq
    START WITH 1
    INCREMENT BY 1
    MINVALUE 1
    MAXVALUE 99999;

CREATE TABLE player (
    id_player VARCHAR(8) PRIMARY KEY,
    name VARCHAR(50) NOT NULL DEFAULT 'unknown'
);

CREATE SEQUENCE match_id_seq
    START WITH 1
    INCREMENT BY 1
    MINVALUE 1
    MAXVALUE 99999;

CREATE TABLE match (
    id_match VARCHAR(8) PRIMARY KEY,
    name VARCHAR(50) UNIQUE NOT NULL DEFAULT 'M' || nextval('match_id_seq'),
    date TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE match_player (
    id SERIAL PRIMARY KEY,
    id_match VARCHAR(8) REFERENCES match(id_match),
    id_player VARCHAR(8) REFERENCES player(id_player),
    profit DOUBLE PRECISION NOT NULL DEFAULT 0,
    loss DOUBLE PRECISION NOT NULL DEFAULT 0
);

CREATE TABLE configuration (
    score INT NOT NULL DEFAULT 0,
    token INT NOT NULL DEFAULT 0
);

INSERT INTO configuration (score, token) VALUES (3, 100);

CREATE OR REPLACE VIEW v_liste_joueur_argent AS
    SELECT p.id_player, p.name, 
    COALESCE(SUM(mp.profit), 0) AS profit,
    COALESCE(SUM(mp.loss), 0) AS loss,
    COALESCE(SUM(mp.profit), 0) - COALESCE(SUM(mp.loss), 0) AS balance
    FROM player p
    LEFT JOIN match_player mp ON p.id_player = mp.id_player
    GROUP BY p.id_player, p.name
    ORDER BY p.id_player;