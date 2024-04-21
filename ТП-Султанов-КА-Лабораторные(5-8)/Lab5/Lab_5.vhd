LIBRARY ieee;
USE ieee.std_logic_1164.all; 
library IEEE;
use IEEE.STD_LOGIC_1164.All;
entity lab_5 is 
	Port(INO1: in STD_LOGIC;
		  INO2: in STD_LOGIC;
		  OO: out STD_LOGIC);
end lab_5;

architecture Behavioral of lab_5 is
SIGNAL	NINO2 :  STD_LOGIC;
begin
NINO2 <= NOT INO2;
OO <= INO1 or NINO2;
end Behavioral;
