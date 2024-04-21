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

-- DATE "05/11/2022 01:07:08"

-- 
-- Device: Altera EP4CGX15BF14C6 Package FBGA169
-- 

-- 
-- This VHDL file should be used for ModelSim-Altera (VHDL) only
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

ENTITY 	lab_2 IS
    PORT (
	C : IN std_logic;
	Q0 : BUFFER std_logic;
	Q2 : BUFFER std_logic;
	Q1 : BUFFER std_logic;
	Q3 : BUFFER std_logic
	);
END lab_2;

-- Design Ports Information
-- Q0	=>  Location: PIN_K8,	 I/O Standard: 2.5 V,	 Current Strength: Default
-- Q2	=>  Location: PIN_L9,	 I/O Standard: 2.5 V,	 Current Strength: Default
-- Q1	=>  Location: PIN_K9,	 I/O Standard: 2.5 V,	 Current Strength: Default
-- Q3	=>  Location: PIN_N11,	 I/O Standard: 2.5 V,	 Current Strength: Default
-- C	=>  Location: PIN_M9,	 I/O Standard: 2.5 V,	 Current Strength: Default


ARCHITECTURE structure OF lab_2 IS
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
SIGNAL ww_Q2 : std_logic;
SIGNAL ww_Q1 : std_logic;
SIGNAL ww_Q3 : std_logic;
SIGNAL \Q0~output_o\ : std_logic;
SIGNAL \Q2~output_o\ : std_logic;
SIGNAL \Q1~output_o\ : std_logic;
SIGNAL \Q3~output_o\ : std_logic;
SIGNAL \C~input_o\ : std_logic;
SIGNAL \DFF_inst~0_combout\ : std_logic;
SIGNAL \DFF_inst~feeder_combout\ : std_logic;
SIGNAL \DFF_inst~q\ : std_logic;
SIGNAL \DFF_inst2~0_combout\ : std_logic;
SIGNAL \DFF_inst2~feeder_combout\ : std_logic;
SIGNAL \DFF_inst2~q\ : std_logic;
SIGNAL \DFF_inst4~0_combout\ : std_logic;
SIGNAL \DFF_inst4~feeder_combout\ : std_logic;
SIGNAL \DFF_inst4~q\ : std_logic;
SIGNAL \DFF_inst6~0_combout\ : std_logic;
SIGNAL \DFF_inst6~q\ : std_logic;
SIGNAL \ALT_INV_DFF_inst2~q\ : std_logic;
SIGNAL \ALT_INV_DFF_inst4~q\ : std_logic;
SIGNAL \ALT_INV_DFF_inst~q\ : std_logic;

COMPONENT hard_block
    PORT (
	devoe : IN std_logic;
	devclrn : IN std_logic;
	devpor : IN std_logic);
END COMPONENT;

BEGIN

ww_C <= C;
Q0 <= ww_Q0;
Q2 <= ww_Q2;
Q1 <= ww_Q1;
Q3 <= ww_Q3;
ww_devoe <= devoe;
ww_devclrn <= devclrn;
ww_devpor <= devpor;
\ALT_INV_DFF_inst2~q\ <= NOT \DFF_inst2~q\;
\ALT_INV_DFF_inst4~q\ <= NOT \DFF_inst4~q\;
\ALT_INV_DFF_inst~q\ <= NOT \DFF_inst~q\;
auto_generated_inst : hard_block
PORT MAP (
	devoe => ww_devoe,
	devclrn => ww_devclrn,
	devpor => ww_devpor);

-- Location: IOOBUF_X22_Y0_N9
\Q0~output\ : cycloneiv_io_obuf
-- pragma translate_off
GENERIC MAP (
	bus_hold => "false",
	open_drain_output => "false")
-- pragma translate_on
PORT MAP (
	i => \DFF_inst~q\,
	devoe => ww_devoe,
	o => \Q0~output_o\);

-- Location: IOOBUF_X24_Y0_N9
\Q2~output\ : cycloneiv_io_obuf
-- pragma translate_off
GENERIC MAP (
	bus_hold => "false",
	open_drain_output => "false")
-- pragma translate_on
PORT MAP (
	i => \DFF_inst4~q\,
	devoe => ww_devoe,
	o => \Q2~output_o\);

-- Location: IOOBUF_X22_Y0_N2
\Q1~output\ : cycloneiv_io_obuf
-- pragma translate_off
GENERIC MAP (
	bus_hold => "false",
	open_drain_output => "false")
-- pragma translate_on
PORT MAP (
	i => \DFF_inst2~q\,
	devoe => ww_devoe,
	o => \Q1~output_o\);

-- Location: IOOBUF_X26_Y0_N2
\Q3~output\ : cycloneiv_io_obuf
-- pragma translate_off
GENERIC MAP (
	bus_hold => "false",
	open_drain_output => "false")
-- pragma translate_on
PORT MAP (
	i => \DFF_inst6~q\,
	devoe => ww_devoe,
	o => \Q3~output_o\);

-- Location: IOIBUF_X24_Y0_N1
\C~input\ : cycloneiv_io_ibuf
-- pragma translate_off
GENERIC MAP (
	bus_hold => "false",
	simulate_z_as => "z")
-- pragma translate_on
PORT MAP (
	i => ww_C,
	o => \C~input_o\);

-- Location: LCCOMB_X24_Y1_N10
\DFF_inst~0\ : cycloneiv_lcell_comb
-- Equation(s):
-- \DFF_inst~0_combout\ = !\DFF_inst~q\

-- pragma translate_off
GENERIC MAP (
	lut_mask => "0011001100110011",
	sum_lutc_input => "datac")
-- pragma translate_on
PORT MAP (
	datab => \DFF_inst~q\,
	combout => \DFF_inst~0_combout\);

-- Location: LCCOMB_X24_Y1_N6
\DFF_inst~feeder\ : cycloneiv_lcell_comb
-- Equation(s):
-- \DFF_inst~feeder_combout\ = \DFF_inst~0_combout\

-- pragma translate_off
GENERIC MAP (
	lut_mask => "1010101010101010",
	sum_lutc_input => "datac")
-- pragma translate_on
PORT MAP (
	dataa => \DFF_inst~0_combout\,
	combout => \DFF_inst~feeder_combout\);

-- Location: FF_X24_Y1_N7
DFF_inst : dffeas
-- pragma translate_off
GENERIC MAP (
	is_wysiwyg => "true",
	power_up => "low")
-- pragma translate_on
PORT MAP (
	clk => \C~input_o\,
	d => \DFF_inst~feeder_combout\,
	devclrn => ww_devclrn,
	devpor => ww_devpor,
	q => \DFF_inst~q\);

-- Location: LCCOMB_X24_Y1_N24
\DFF_inst2~0\ : cycloneiv_lcell_comb
-- Equation(s):
-- \DFF_inst2~0_combout\ = !\DFF_inst2~q\

-- pragma translate_off
GENERIC MAP (
	lut_mask => "0000000011111111",
	sum_lutc_input => "datac")
-- pragma translate_on
PORT MAP (
	datad => \DFF_inst2~q\,
	combout => \DFF_inst2~0_combout\);

-- Location: LCCOMB_X24_Y1_N16
\DFF_inst2~feeder\ : cycloneiv_lcell_comb
-- Equation(s):
-- \DFF_inst2~feeder_combout\ = \DFF_inst2~0_combout\

-- pragma translate_off
GENERIC MAP (
	lut_mask => "1111111100000000",
	sum_lutc_input => "datac")
-- pragma translate_on
PORT MAP (
	datad => \DFF_inst2~0_combout\,
	combout => \DFF_inst2~feeder_combout\);

-- Location: FF_X24_Y1_N17
DFF_inst2 : dffeas
-- pragma translate_off
GENERIC MAP (
	is_wysiwyg => "true",
	power_up => "low")
-- pragma translate_on
PORT MAP (
	clk => \ALT_INV_DFF_inst~q\,
	d => \DFF_inst2~feeder_combout\,
	devclrn => ww_devclrn,
	devpor => ww_devpor,
	q => \DFF_inst2~q\);

-- Location: LCCOMB_X25_Y1_N2
\DFF_inst4~0\ : cycloneiv_lcell_comb
-- Equation(s):
-- \DFF_inst4~0_combout\ = !\DFF_inst4~q\

-- pragma translate_off
GENERIC MAP (
	lut_mask => "0000111100001111",
	sum_lutc_input => "datac")
-- pragma translate_on
PORT MAP (
	datac => \DFF_inst4~q\,
	combout => \DFF_inst4~0_combout\);

-- Location: LCCOMB_X25_Y1_N6
\DFF_inst4~feeder\ : cycloneiv_lcell_comb
-- Equation(s):
-- \DFF_inst4~feeder_combout\ = \DFF_inst4~0_combout\

-- pragma translate_off
GENERIC MAP (
	lut_mask => "1111000011110000",
	sum_lutc_input => "datac")
-- pragma translate_on
PORT MAP (
	datac => \DFF_inst4~0_combout\,
	combout => \DFF_inst4~feeder_combout\);

-- Location: FF_X25_Y1_N7
DFF_inst4 : dffeas
-- pragma translate_off
GENERIC MAP (
	is_wysiwyg => "true",
	power_up => "low")
-- pragma translate_on
PORT MAP (
	clk => \ALT_INV_DFF_inst2~q\,
	d => \DFF_inst4~feeder_combout\,
	devclrn => ww_devclrn,
	devpor => ww_devpor,
	q => \DFF_inst4~q\);

-- Location: LCCOMB_X25_Y1_N8
\DFF_inst6~0\ : cycloneiv_lcell_comb
-- Equation(s):
-- \DFF_inst6~0_combout\ = !\DFF_inst6~q\

-- pragma translate_off
GENERIC MAP (
	lut_mask => "0000111100001111",
	sum_lutc_input => "datac")
-- pragma translate_on
PORT MAP (
	datac => \DFF_inst6~q\,
	combout => \DFF_inst6~0_combout\);

-- Location: FF_X25_Y1_N9
DFF_inst6 : dffeas
-- pragma translate_off
GENERIC MAP (
	is_wysiwyg => "true",
	power_up => "low")
-- pragma translate_on
PORT MAP (
	clk => \ALT_INV_DFF_inst4~q\,
	d => \DFF_inst6~0_combout\,
	devclrn => ww_devclrn,
	devpor => ww_devpor,
	q => \DFF_inst6~q\);

ww_Q0 <= \Q0~output_o\;

ww_Q2 <= \Q2~output_o\;

ww_Q1 <= \Q1~output_o\;

ww_Q3 <= \Q3~output_o\;
END structure;


