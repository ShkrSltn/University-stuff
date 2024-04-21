LIBRARY ieee;
USE ieee.std_logic_1164.all; 

LIBRARY work;

ENTITY lab_4 IS 
	PORT
	(
		C :  IN  STD_LOGIC;
		Q0 :  OUT  STD_LOGIC;
		Q1 :  OUT  STD_LOGIC;
		Q2 :  OUT  STD_LOGIC;
		Q3 :  OUT  STD_LOGIC
	);
END lab_4;

ARCHITECTURE behavioral OF lab_4 IS 
SIGNAL	JKforJK1 :  STD_LOGIC;
SIGNAL	QforJK1 :  STD_LOGIC;
SIGNAL	AND1out :  STD_LOGIC;
SIGNAL	AND2out :  STD_LOGIC;
SIGNAL	QforJK2 :  STD_LOGIC;
SIGNAL	QforJK3 :  STD_LOGIC;

BEGIN 
Q0 <= QforJK1;
Q1 <= QforJK2;
Q2 <= QforJK3;
JKforJK1 <= '1';

PROCESS(C)
VARIABLE var_for_QforJK1 : STD_LOGIC;
BEGIN
IF (RISING_EDGE(C)) THEN
	var_for_QforJK1 := (NOT(var_for_QforJK1) AND JKforJK1) OR (var_for_QforJK1 AND (NOT(JKforJK1)));
END IF;
	QforJK1 <= var_for_QforJK1;
END PROCESS;

PROCESS(C)
VARIABLE var_for_QforJK2 : STD_LOGIC;
BEGIN
IF (RISING_EDGE(C)) THEN
	var_for_QforJK2 := (NOT(var_for_QforJK2) AND QforJK1) OR (var_for_QforJK2 AND (NOT(QforJK1)));
END IF;
	QforJK2 <= var_for_QforJK2;
END PROCESS;

PROCESS(C)
VARIABLE var_for_QforJK3 : STD_LOGIC;
BEGIN
IF (RISING_EDGE(C)) THEN
	var_for_QforJK3 := (NOT(var_for_QforJK3) AND AND1out) OR (var_for_QforJK3 AND (NOT(AND1out)));
END IF;
	QforJK3 <= var_for_QforJK3;
END PROCESS;

PROCESS(C)
VARIABLE var_for_QforJK4 : STD_LOGIC;
BEGIN
IF (RISING_EDGE(C)) THEN
	var_for_QforJK4 := (NOT(var_for_QforJK4) AND AND2out) OR (var_for_QforJK4 AND (NOT(AND2out)));
END IF;
	Q3 <= var_for_QforJK4;
END PROCESS;

AND1out <= QforJK1 AND QforJK2;
AND2out <= AND1out AND QforJK3;

END behavioral;
