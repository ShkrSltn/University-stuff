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
-- Generated on "05/11/2022 03:05:38"
                                                             
-- Vhdl Test Bench(with test vectors) for design  :          lab_6
-- 
-- Simulation tool : 3rd Party
-- 

LIBRARY ieee;                                               
USE ieee.std_logic_1164.all;                                

ENTITY lab_6_vhd_vec_tst IS
END lab_6_vhd_vec_tst;
ARCHITECTURE lab_6_arch OF lab_6_vhd_vec_tst IS
-- constants                                                 
-- signals                                                   
SIGNAL C : STD_LOGIC;
SIGNAL D : STD_LOGIC;
SIGNAL Q : STD_LOGIC;
SIGNAL R : STD_LOGIC;
COMPONENT lab_6
	PORT (
	C : IN STD_LOGIC;
	D : IN STD_LOGIC;
	Q : OUT STD_LOGIC;
	R : IN STD_LOGIC
	);
END COMPONENT;
BEGIN
	i1 : lab_6
	PORT MAP (
-- list connections between master ports and signals
	C => C,
	D => D,
	Q => Q,
	R => R
	);

-- C
t_prcs_C: PROCESS
BEGIN
	FOR i IN 1 TO 12
	LOOP
		C <= '0';
		WAIT FOR 40000 ps;
		C <= '1';
		WAIT FOR 40000 ps;
	END LOOP;
	C <= '0';
WAIT;
END PROCESS t_prcs_C;

-- D
t_prcs_D: PROCESS
BEGIN
	FOR i IN 1 TO 2
	LOOP
		D <= '0';
		WAIT FOR 200000 ps;
		D <= '1';
		WAIT FOR 200000 ps;
	END LOOP;
	D <= '0';
WAIT;
END PROCESS t_prcs_D;

-- R
t_prcs_R: PROCESS
BEGIN
	R <= '0';
	WAIT FOR 240000 ps;
	R <= '1';
	WAIT FOR 120000 ps;
	R <= '0';
	WAIT FOR 160000 ps;
	R <= '1';
	WAIT FOR 160000 ps;
	R <= '0';
WAIT;
END PROCESS t_prcs_R;
END lab_6_arch;
