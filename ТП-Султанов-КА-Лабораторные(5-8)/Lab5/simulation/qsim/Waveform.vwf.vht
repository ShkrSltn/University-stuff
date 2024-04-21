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
-- Generated on "05/11/2022 02:42:02"
                                                             
-- Vhdl Test Bench(with test vectors) for design  :          lab_5
-- 
-- Simulation tool : 3rd Party
-- 

LIBRARY ieee;                                               
USE ieee.std_logic_1164.all;                                

ENTITY lab_5_vhd_vec_tst IS
END lab_5_vhd_vec_tst;
ARCHITECTURE lab_5_arch OF lab_5_vhd_vec_tst IS
-- constants                                                 
-- signals                                                   
SIGNAL INO1 : STD_LOGIC;
SIGNAL INO2 : STD_LOGIC;
SIGNAL OO : STD_LOGIC;
COMPONENT lab_5
	PORT (
	INO1 : IN STD_LOGIC;
	INO2 : IN STD_LOGIC;
	OO : OUT STD_LOGIC
	);
END COMPONENT;
BEGIN
	i1 : lab_5
	PORT MAP (
-- list connections between master ports and signals
	INO1 => INO1,
	INO2 => INO2,
	OO => OO
	);

-- INO1
t_prcs_INO1: PROCESS
BEGIN
LOOP
	INO1 <= '0';
	WAIT FOR 10000 ps;
	INO1 <= '1';
	WAIT FOR 10000 ps;
	IF (NOW >= 1000000 ps) THEN WAIT; END IF;
END LOOP;
END PROCESS t_prcs_INO1;

-- INO2
t_prcs_INO2: PROCESS
BEGIN
LOOP
	INO2 <= '0';
	WAIT FOR 10000 ps;
	INO2 <= '1';
	WAIT FOR 10000 ps;
	IF (NOW >= 1000000 ps) THEN WAIT; END IF;
END LOOP;
END PROCESS t_prcs_INO2;
END lab_5_arch;
