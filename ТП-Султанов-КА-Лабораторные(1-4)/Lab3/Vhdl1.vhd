LIBRARY ieee;
USE ieee.std_logic_1164.all; 
LIBRARY work;

ENTITY lab_3 IS 
	PORT
	(
		C :  IN  STD_LOGIC;
		Q0 :  OUT  STD_LOGIC;
		Q1 :  OUT  STD_LOGIC;
		Q2 :  OUT  STD_LOGIC;
		Q3 :  OUT  STD_LOGIC
	);
END lab_3;

ARCHITECTURE bdf_type OF lab_3 IS 
SIGNAL	SYNTHESIZED_WIRE_11 :  STD_LOGIC;
SIGNAL	SYNTHESIZED_WIRE_12 :  STD_LOGIC;
SIGNAL	SYNTHESIZED_WIRE_4 :  STD_LOGIC;
SIGNAL	SYNTHESIZED_WIRE_13 :  STD_LOGIC;
SIGNAL	SYNTHESIZED_WIRE_7 :  STD_LOGIC;
SIGNAL	SYNTHESIZED_WIRE_14 :  STD_LOGIC;
SIGNAL	SYNTHESIZED_WIRE_10 :  STD_LOGIC;
SIGNAL	JKFF_inst :  STD_LOGIC;
SIGNAL	JKFF_inst1 :  STD_LOGIC;
SIGNAL	JKFF_inst2 :  STD_LOGIC;

BEGIN 
Q0 <= JKFF_inst;
Q1 <= JKFF_inst1;
Q2 <= JKFF_inst2;
SYNTHESIZED_WIRE_11 <= '1';
SYNTHESIZED_WIRE_12 <= '1';
SYNTHESIZED_WIRE_13 <= '1';
SYNTHESIZED_WIRE_14 <= '1';

PROCESS(C)
VARIABLE synthesized_var_for_JKFF_inst : STD_LOGIC;
BEGIN
IF (RISING_EDGE(C)) THEN
	synthesized_var_for_JKFF_inst := (NOT(synthesized_var_for_JKFF_inst) AND SYNTHESIZED_WIRE_11) OR (synthesized_var_for_JKFF_inst AND (NOT(SYNTHESIZED_WIRE_11)));
END IF;
	JKFF_inst <= synthesized_var_for_JKFF_inst;
END PROCESS;

PROCESS(SYNTHESIZED_WIRE_4)
VARIABLE synthesized_var_for_JKFF_inst1 : STD_LOGIC;
BEGIN
IF (RISING_EDGE(SYNTHESIZED_WIRE_4)) THEN
	synthesized_var_for_JKFF_inst1 := (NOT(synthesized_var_for_JKFF_inst1) AND SYNTHESIZED_WIRE_12) OR (synthesized_var_for_JKFF_inst1 AND (NOT(SYNTHESIZED_WIRE_12)));
END IF;
	JKFF_inst1 <= synthesized_var_for_JKFF_inst1;
END PROCESS;

PROCESS(SYNTHESIZED_WIRE_7)
VARIABLE synthesized_var_for_JKFF_inst2 : STD_LOGIC;
BEGIN
IF (RISING_EDGE(SYNTHESIZED_WIRE_7)) THEN
	synthesized_var_for_JKFF_inst2 := (NOT(synthesized_var_for_JKFF_inst2) AND SYNTHESIZED_WIRE_13) OR (synthesized_var_for_JKFF_inst2 AND (NOT(SYNTHESIZED_WIRE_13)));
END IF;
	JKFF_inst2 <= synthesized_var_for_JKFF_inst2;
END PROCESS;

PROCESS(SYNTHESIZED_WIRE_10)
VARIABLE synthesized_var_for_Q3 : STD_LOGIC;
BEGIN
IF (RISING_EDGE(SYNTHESIZED_WIRE_10)) THEN
	synthesized_var_for_Q3 := (NOT(synthesized_var_for_Q3) AND SYNTHESIZED_WIRE_14) OR (synthesized_var_for_Q3 AND (NOT(SYNTHESIZED_WIRE_14)));
END IF;
	Q3 <= synthesized_var_for_Q3;
END PROCESS;

SYNTHESIZED_WIRE_4 <= NOT(JKFF_inst);
SYNTHESIZED_WIRE_7 <= NOT(JKFF_inst1);
SYNTHESIZED_WIRE_10 <= NOT(JKFF_inst2);
END bdf_type;
