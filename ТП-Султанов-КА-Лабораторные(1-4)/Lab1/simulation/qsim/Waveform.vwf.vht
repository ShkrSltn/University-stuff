-- Copyright (C) 2020  Intel Corporation. All rights reserved.
-- Your use of Intel Corporation's design tools, logic functions 
-- and other software and tools, and any partner logic 
-- functions, and any output files from any of the foregoing 
-- (including device programming or simulation files), and any 
-- associated documentation or information are expressly subject 
-- to the terms and conditions of the Intel Program License 
-- Subscription Agreement, the Intel Quartus Prime License Agreement,
-- the Intel FPGA IP License Agreement, or other applicable license
-- agreement, including, without limitation, that your use is for
-- the sole purpose of programming logic devices manufactured by
-- Intel and sold by Intel or its authorized distributors.  Please
-- refer to the applicable agreement for further details, at
-- https://fpgasoftware.intel.com/eula.

-- *****************************************************************************
-- This file contains a Vhdl test bench with test vectors .The test vectors     
-- are exported from a vector file in the Quartus Waveform Editor and apply to  
-- the top level entity of the current Quartus project .The user can use this   
-- testbench to simulate his design using a third-party simulation tool .       
-- *****************************************************************************
-- Generated on "05/10/2022 18:56:56"
                                                             
-- Vhdl Test Bench(with test vectors) for design  :          lab_1
-- 
-- Simulation tool : 3rd Party
-- 

LIBRARY ieee;                                               
USE ieee.std_logic_1164.all;                                

ENTITY lab_1_vhd_vec_tst IS
END lab_1_vhd_vec_tst;
ARCHITECTURE lab_1_arch OF lab_1_vhd_vec_tst IS
-- constants                                                 
-- signals                                                   
SIGNAL INO1 : STD_LOGIC;
SIGNAL INO2 : STD_LOGIC;
SIGNAL OO : STD_LOGIC;
COMPONENT lab_1
	PORT (
	INO1 : IN STD_LOGIC;
	INO2 : IN STD_LOGIC;
	OO : OUT STD_LOGIC
	);
END COMPONENT;
BEGIN
	i1 : lab_1
	PORT MAP (
-- list connections between master ports and signals
	INO1 => INO1,
	INO2 => INO2,
	OO => OO
	);

-- INO1
t_prcs_INO1: PROCESS
BEGIN
	FOR i IN 1 TO 2
	LOOP
		INO1 <= '0';
		WAIT FOR 2000 ps;
		INO1 <= '1';
		WAIT FOR 2000 ps;
	END LOOP;
	INO1 <= '0';
WAIT;
END PROCESS t_prcs_INO1;

-- INO2
t_prcs_INO2: PROCESS
BEGIN
LOOP
	INO2 <= '0';
	WAIT FOR 1000 ps;
	INO2 <= '1';
	WAIT FOR 1000 ps;
	IF (NOW >= 10000 ps) THEN WAIT; END IF;
END LOOP;
END PROCESS t_prcs_INO2;
END lab_1_arch;
