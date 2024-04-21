LIBRARY ieee;
USE ieee.std_logic_1164.all; 
LIBRARY work;

ENTITY lab_6 IS 
	PORT
	(
		D :  IN  STD_LOGIC;
		C :  IN  STD_LOGIC;
		R :  IN  STD_LOGIC;
		Q :  OUT  STD_LOGIC
	);
END lab_6;

ARCHITECTURE lab6_arc OF lab_6 IS 
SIGNAL Q1: STD_LOGIC;
SIGNAL NC: STD_LOGIC;
BEGIN
PROCESS(C,R)
BEGIN
IF (R = '1') THEN
	Q1 <= '0';ELSIF (RISING_EDGE(C)) THEN
	Q1 <= D;
END IF;
END PROCESS;

NC <= not C;

PROCESS(NC,R)
BEGIN
IF (R = '1') THEN
	Q <= '0';
ELSIF (RISING_EDGE(NC)) THEN
	Q <= Q1;
END IF;
END PROCESS;

END lab6_arc;
