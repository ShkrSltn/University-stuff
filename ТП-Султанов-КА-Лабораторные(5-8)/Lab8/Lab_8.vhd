library IEEE;
use IEEE.STD_LOGIC_1164.All;

entity lab_8 is 
	Port(X1: in STD_LOGIC;
		  X2: in STD_LOGIC;
		  X3: in STD_LOGIC;
		  X4: in STD_LOGIC;
		  F: out STD_LOGIC
		  );
end lab_8;

architecture Behavioral of lab_8 is
Signal nX1: STD_LOGIC;
Signal nX2: STD_LOGIC;
Signal nX3: STD_LOGIC;
Signal nX4: STD_LOGIC;

begin 
nX1 <= not X1;
nX2 <= not X2;
nX3 <= not X3;
nX4 <= not X4;

F <= (nX1 and nX2 and nX3 and nX4) or (nX1 and nX2 and X3 and X4) or (nX1 and X2 and nX3 and X4) or 
(X1 and nX2 and nX3 and X4) or (nX1 and X2 and X3 and nX4) or (X1 and nX2 and X3 and nX4) or (X1 and X2 and nX3 and nX4) or (X1 and X2 and X3 and X4);
end Behavioral;

