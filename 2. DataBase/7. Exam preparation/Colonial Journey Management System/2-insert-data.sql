INSERT INTO travel_cards(card_number, job_during_journey, journey_id, colonist_id)
SELECT 
	IF(
		birth_date > '1980-01-01',
        CONCAT(YEAR(birth_date), DAY(birth_date), SUBSTR(ucn, 1, 4)),
        CONCAT(YEAR(birth_date), DAY(birth_date), SUBSTR(ucn, 7, 4))
	),
    IF(
		id % 2 = 0, 
        'Pilot',
		IF(id % 3 = 0, 
			'Cook',
            'Engineer'
		)
	),
    SUBSTR(ucn, 1, 1) AS journey_id,
    id
FROM colonists
WHERE id >= 96 AND id <= 100;