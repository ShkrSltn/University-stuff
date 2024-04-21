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

-- VENDOR "Altera"
-- PROGRAM "Quartus Prime"
-- VERSION "Version 20.1.1 Build 720 11/11/2020 SJ Lite Edition"

-- DATE "05/11/2022 01:30:34"

-- 
-- Device: Altera EP4CGX15BF14C6 Package FBGA169
-- 

-- 
-- This VHDL file should be used for ModelSim (VHDL) only
-- 

LIBRARY CYCLONEIV;
LIBRARY IEEE;
USE CYCLONEIV.CYCLONEIV_COMPONENTS.ALL;
USE IEEE.STD_LOGIC_1164.ALL;

ENTITY 	hard_block IS
    PORT (
	devoe : IN std_logic;
	devclrn : IN std_logic;
	devpor : IN std_logic
	);
END hard_block;

-- Design Ports Information
-- ~ALTERA_NCEO~	=>  Location: PIN_N5,	 I/O Standard: 2.5 V,	 Current Strength: 16mA
-- ~ALTERA_DATA0~	=>  Location: PIN_A5,	 I/O Standard: 2.5 V,	 Current Strength: Default
-- ~ALTERA_ASDO~	=>  Location: PIN_B5,	 I/O Standard: 2.5 V,	 Current Strength: Default
-- ~ALTERA_NCSO~	=>  Location: PIN_C5,	 I/O Standard: 2.5 V,	 Current Strength: Default
-- ~ALTERA_DCLK~	=>  Location: PIN_A4,	 I/O Standard: 2.5 V,	 Current Strength: Default


ARCHITECTURE structure OF hard_block IS
SIGNAL gnd : std_logic := '0';
SIGNAL vcc : std_logic := '1';
SIGNAL unknown : std_logic := 'X';
SIGNAL ww_devoe : std_logic;
SIGNAL ww_devclrn : std_logic;
SIGNAL ww_devpor : std_logic;
SIGNAL \~ALTERA_DATA0~~padout\ : std_logic;
SIGNAL \~ALTERA_ASDO~~padout\ : std_logic;
SIGNAL \~ALTERA_NCSO~~padout\ : std_logic;
SIGNAL \~ALTERA_DATA0~~ibuf_o\ : std_logic;
SIGNAL \~ALTERA_ASDO~~ibuf_o\ : std_logic;
SIGNAL \~ALTERA_NCSO~~ibuf_o\ : std_logic;

BEGIN

ww_devoe <= devoe;
ww_devclrn <= devclrn;
ww_devpor <= devpor;
END structure;


LIBRARY ALTERA;
LIBRARY CYCLONEIV;
LIBRARY IEEE;
USE ALTERA.ALTERA_PRIMITIVES_COMPONENTS.ALL;
USE CYCLONEIV.CYCLONEIV_COMPONENTS.ALL;
USE IEEE.STD_LOGIC_1164.ALL;

ENTITY 	lab_3 IS
    PORT (
	C : IN std_logic;
	Q0 : BUFFER std_logic;
	Q1 : BUFFER std_logic;
	Q2 : BUFFER std_logic;
	Q3 : BUFFER std_logic
	);
END lab_3;

-- Design Ports Information
-- Q0	=>  Location: PIN_A11,	 I/O Standard: 2.5 V,	 Current Strength: Default
-- Q1	=>  Location: PIN_A12,	 I/O Standard: 2.5 V,	 Current Strength: Default
-- Q2	=>  Location: PIN_B11,	 I/O Standard: 2.5 V,	 Current Strength: Default
-- Q3	=>  Location: PIN_C8,	 I/O Standard: 2.5 V,	 Current Strength: Default
-- C	=>  Location: PIN_B8,	 I/O Standard: 2.5 V,	 Current Strength: Default


ARCHITECTURE structure OF lab_3 IS
SIGNAL gnd : std_logic := '0';
SIGNAL vcc : std_logic := '1';
SIGNAL unknown : std_logic := 'X';
SIGNAL devoe : std_logic := '1';
SIGNAL devclrn : std_logic := '1';
SIGNAL devpor : std_logic := '1';
SIGNAL ww_devoe : std_logic;
SIGNAL ww_devclrn : std_logic;
SIGNAL ww_devpor : std_logic;
SIGNAL ww_C : std_logic;
SIGNAL ww_Q0 : std_logic;
SIGNAL ww_Q1 : std_logic;
SIGNAL ww_Q2 : std_logic;
SIGNAL ww_Q3 : std_logic;
SIGNAL \Q0~output_o\ : std_logic;
SIGNAL \Q1~output_o\ : std_logic;
SIGNAL \Q2~output_o\ : std_logic;
SIGNAL \Q3~output_o\ : std_logic;
SIGNAL \C~input_o\ : std_logic;
SIGNAL \synthesized_var_for_JKFF_inst~0_combout\ : std_logic;
SIGNAL \synthesized_var_for_JKFF_inst~feeder_combout\ : std_logic;
SIGNAL \synthesized_var_for_JKFF_inst~q\ : std_logic;
SIGNAL \synthesized_var_for_JKFF_inst1~0_combout\ : std_logic;
SIGNAL \synthesized_var_for_JKFF_inst1~feeder_combout\ : std_logic;
SIGNAL \synthesized_var_for_JKFF_inst1~q\ : std_logic;
SIGNAL \synthesized_var_for_JKFF_inst2~0_combout\ : std_logic;
SIGNAL \synthesized_var_for_JKFF_inst2~feeder_combout\ : std_logic;
SIGNAL \synthesized_var_for_JKFF_inst2~q\ : std_logic;
SIGNAL \synthesized_var_for_Q3~0_combout\ : std_logic;
SIGNAL \synthesized_var_for_Q3~q\ : std_logic;
SIGNAL \ALT_INV_synthesized_var_for_JKFF_inst2~q\ : std_logic;
SIGNAL \ALT_INV_synthesized_var_for_JKFF_inst1~q\ : std_logic;
SIGNAL \ALT_INV_synthesized_var_for_JKFF_inst~q\ : std_logic;

COMPONENT hard_block
    PORT (
	devoe : IN std_logic;
	devclrn : IN std_logic;
	devpor : IN std_logic);
END COMPONENT;

BEGIN

ww_C <= C;
Q0 <= ww_Q0;
Q1 <= ww_Q1;
Q2 <= ww_Q2;
Q3 <= ww_Q3;
ww_devoe <= devoe;
ww_devclrn <= devclrn;
ww_devpor <= devpor;
\ALT_INV_synthesized_var_for_JKFF_inst2~q\ <= NOT \synthesized_var_for_JKFF_inst2~q\;
\ALT_INV_synthesized_var_for_JKFF_inst1~q\ <= NOT \synthesized_var_for_JKFF_inst1~q\;
\ALT_INV_synthesized_var_for_JKFF_inst~q\ <= NOT \synthesized_var_for_JKFF_inst~q\;
auto_generated_inst : hard_block
PORT MAP (
	devoe => ww_devoe,
	devclrn => ww_devclrn,
	devpor => ww_devpor);

-- Location: IOOBUF_X20_Y31_N2
\Q0~output\ : cycloneiv_io_obuf
-- pragma translate_off
GENERIC MAP (
	bus_hold => "false",
	open_drain_output => "false")
-- pragma translate_on
PORT MAP (
	i => \synthesized_var_for_JKFF_inst~q\,
	devoe => ww_devoe,
	o => \Q0~output_o\);

-- Location: IOOBUF_X20_Y31_N9
\Q1~output\ : cycloneiv_io_obuf
-- pragma translate_off
GENERIC MAP (
	bus_hold => "false",
	open_drain_output => "false")
-- pragma translate_on
PORT MAP (
	i => \synthesized_var_for_JKFF_inst1~q\,
	devoe => ww_devoe,
	o => \Q1~output_o\);

-- Location: IOOBUF_X24_Y31_N2
\Q2~output\ : cycloneiv_io_obuf
-- pragma translate_off
GENERIC MAP (
	bus_hold => "false",
	open_drain_output => "false")
-- pragma translate_on
PORT MAP (
	i => \synthesized_var_for_JKFF_inst2~q\,
	devoe => ww_devoe,
	o => \Q2~output_o\);

-- Location: IOOBUF_X22_Y31_N9
\Q3~output\ : cycloneiv_io_obuf
-- pragma translate_off
GENERIC MAP (
	bus_hold => "false",
	open_drain_output => "false")
-- pragma translate_on
PORT MAP (
	i => \synthesized_var_for_Q3~q\,
	devoe => ww_devoe,
	o => \Q3~output_o\);

-- Location: IOIBUF_X22_Y31_N1
\C~input\ : cycloneiv_io_ibuf
-- pragma translate_off
GENERIC MAP (
	bus_hold => "false",
	simulate_z_as => "z")
-- pragma translate_on
PORT MAP (
	i => ww_C,
	o => \C~input_o\);

-- Location: LCCOMB_X22_Y30_N28
\synthesized_var_for_JKFF_inst~0\ : cycloneiv_lcell_comb
-- Equation(s):
-- \synthesized_var_for_JKFF_inst~0_combout\ = !\synthesized_var_for_JKFF_inst~q\

-- pragma translate_off
GENERIC MAP (
	lut_mask => "0101010101010101",
	sum_lutc_input => "datac")
-- pragma translate_on
PORT MAP (
	dataa => \synthesized_var_for_JKFF_inst~q\,
	combout => \synthesized_var_for_JKFF_inst~0_combout\);

-- Location: LCCOMB_X22_Y30_N12
\synthesized_var_for_JKFF_inst~feeder\ : cycloneiv_lcell_comb
-- Equation(s):
-- \synthesized_var_for_JKFF_inst~feeder_combout\ = \synthesized_var_for_JKFF_inst~0_combout\

-- pragma translate_off
GENERIC MAP (
	lut_mask => "1100110011001100",
	sum_lutc_input => "datac")
-- pragma translate_on
PORT MAP (
	datab => \synthesized_var_for_JKFF_inst~0_combout\,
	combout => \synthesized_var_for_JKFF_inst~feeder_combout\);

-- Location: FF_X22_Y30_N13
synthesized_var_for_JKFF_inst : dffeas
-- pragma translate_off
GENERIC MAP (
	is_wysiwyg => "true",
	power_up => "low")
-- pragma translate_on
PORT MAP (
	clk => \C~input_o\,
	d => \synthesized_var_for_JKFF_inst~feeder_combout\,
	devclrn => ww_devclrn,
	devpor => ww_devpor,
	q => \synthesized_var_for_JKFF_inst~q\);

-- Location: LCCOMB_X22_Y30_N18
\synthesized_var_for_JKFF_inst1~0\ : cycloneiv_lcell_comb
-- Equation(s):
-- \synthesized_var_for_JKFF_inst1~0_combout\ = !\synthesized_var_for_JKFF_inst1~q\

-- pragma translate_off
GENERIC MAP (
	lut_mask => "0000000011111111",
	sum_lutc_input => "datac")
-- pragma translate_on
PORT MAP (
	datad => \synthesized_var_for_JKFF_inst1~q\,
	combout => \synthesized_var_for_JKFF_inst1~0_combout\);

-- Location: LCCOMB_X22_Y30_N30
\synthesized_var_for_JKFF_inst1~feeder\ : cycloneiv_lcell_comb
-- Equation(s):
-- \synthesized_var_for_JKFF_inst1~feeder_combout\ = \synthesized_var_for_JKFF_inst1~0_combout\

-- pragma translate_off
GENERIC MAP (
	lut_mask => "1010101010101010",
	sum_lutc_input => "datac")
-- pragma translate_on
PORT MAP (
	dataa => \synthesized_var_for_JKFF_inst1~0_combout\,
	combout => \synthesized_var_for_JKFF_inst1~feeder_combout\);

-- Location: FF_X22_Y30_N31
synthesized_var_for_JKFF_inst1 : dffeas
-- pragma translate_off
GENERIC MAP (
	is_wysiwyg => "true",
	power_up => "low")
-- pragma translate_on
PORT MAP (
	clk => \ALT_INV_synthesized_var_for_JKFF_inst~q\,
	d => \synthesized_var_for_JKFF_inst1~feeder_combout\,
	devclrn => ww_devclrn,
	devpor => ww_devpor,
	q => \synthesized_var_for_JKFF_inst1~q\);

-- Location: LCCOMB_X23_Y30_N20
\synthesized_var_for_JKFF_inst2~0\ : cycloneiv_lcell_comb
-- Equation(s):
-- \synthesized_var_for_JKFF_inst2~0_combout\ = !\synthesized_var_for_JKFF_inst2~q\

-- pragma translate_off
GENERIC MAP (
	lut_mask => "0000111100001111",
	sum_lutc_input => "datac")
-- pragma translate_on
PORT MAP (
	datac => \synthesized_var_for_JKFF_inst2~q\,
	combout => \synthesized_var_for_JKFF_inst2~0_combout\);

-- Location: LCCOMB_X23_Y30_N14
\synthesized_var_for_JKFF_inst2~feeder\ : cycloneiv_lcell_comb
-- Equation(s):
-- \synthesized_var_for_JKFF_inst2~feeder_combout\ = \synthesized_var_for_JKFF_inst2~0_combout\

-- pragma translate_off
GENERIC MAP (
	lut_mask => "1111000011110000",
	sum_lutc_input => "datac")
-- pragma translate_on
PORT MAP (
	datac => \synthesized_var_for_JKFF_inst2~0_combout\,
	combout => \synthesized_var_for_JKFF_inst2~feeder_combout\);

-- Location: FF_X23_Y30_N15
synthesized_var_for_JKFF_inst2 : dffeas
-- pragma translate_off
GENERIC MAP (
	is_wysiwyg => "true",
	power_up => "low")
-- pragma translate_on
PORT MAP (
	clk => \ALT_INV_synthesized_var_for_JKFF_inst1~q\,
	d => \synthesized_var_for_JKFF_inst2~feeder_combout\,
	devclrn => ww_devclrn,
	devpor => ww_devpor,
	q => \synthesized_var_for_JKFF_inst2~q\);

-- Location: LCCOMB_X23_Y30_N16
\synthesized_var_for_Q3~0\ : cycloneiv_lcell_comb
-- Equation(s):
-- \synthesized_var_for_Q3~0_combout\ = !\synthesized_var_for_Q3~q\

-- pragma translate_off
GENERIC MAP (
	lut_mask => "0000111100001111",
	sum_lutc_input => "datac")
-- pragma translate_on
PORT MAP (
	datac => \synthesized_var_for_Q3~q\,
	combout => \synthesized_var_for_Q3~0_combout\);

-- Location: FF_X23_Y30_N17
synthesized_var_for_Q3 : dffeas
-- pragma translate_off
GENERIC MAP (
	is_wysiwyg => "true",
	power_up => "low")
-- pragma translate_on
PORT MAP (
	clk => \ALT_INV_synthesized_var_for_JKFF_inst2~q\,
	d => \synthesized_var_for_Q3~0_combout\,
	devclrn => ww_devclrn,
	devpor => ww_devpor,
	q => \synthesized_var_for_Q3~q\);

ww_Q0 <= \Q0~output_o\;

ww_Q1 <= \Q1~output_o\;

ww_Q2 <= \Q2~output_o\;

ww_Q3 <= \Q3~output_o\;
END structure;


