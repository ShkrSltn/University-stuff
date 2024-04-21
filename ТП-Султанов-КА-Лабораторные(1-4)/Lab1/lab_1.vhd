library IEEE;
use IEEE.STD_LOGIC_1164.All;

entity lab_1 is 
	Port(INO1: in STD_LOGIC;
		  INO2: in STD_LOGIC;
		  OO: out STD_LOGIC);
end lab_1;

architecture Behavioral of lab_1 is
begin 
OO <= INO1 or INO2;
end Behavioral;
