Feature: SpecFlowProjetVote

Scenario: Si un candidat gagne au premier tour
	Given Macron have 200 vote
	And Le Pen have 50 vote
	And Mélanchon have 30 vote
	And Zemmour have 60 vote
	Then Macron have à score of 58.8%
	And Le Pen have à score of 14.7%
	And Mélanchon have à score of 8.8%
	And Zemmour have à score of 17.6%
	When Score is equal or more than 50%
	Then winner is Macron

	Scenario: Si aucun candidat n'a pas plus de 50%, alors on garde les 2 candidats correspondants aux meilleurs pourcentages
	Given Macron have 150 vote
	And Le Pen have 30 vote
	And Mélanchon have 40 vote
	And Zemmour have 120 vote
	Then Macron have à score of 44%
	And Le Pen have à score of 8.8%
	And Mélanchon have à score of 11.7%
	And Zemmour have à score of 35.2%
	When Score is equal or more than 50%
	Then winner is noone
	When second turn with Macron and Zemmour 
	Given Macron have 204 vote	
	And Zemmour have 136 vote
	Then Macron have à score of 60%
	And Zemmour have à score of 40%
	And scond turn winner is Macron

	
	Scenario: Si les candidats finaux ne sont pas départager pas de vainqueur 
	Given Macron have 150 vote
	And Le Pen have 30 vote
	And Mélanchon have 40 vote
	And Zemmour have 120 vote
	Then Macron have à score of 44%
	And Le Pen have à score of 8.8%
	And Mélanchon have à score of 11.7%
	And Zemmour have à score of 35.2%
	When Score is equal or more than 50%
	Then winner is noone
	When second turn with Macron and Zemmour 
	Given Macron have 170 vote	
	And Zemmour have 170 vote
	Then Macron have à score of 50%
	And Zemmour have à score of 50%
	And scond turn winner is noone

	Scenario: On prend en compte les votes blanc
	Given Macron have 140 vote
	And Le Pen have 40 vote
	And Mélanchon have 20 vote
	And Zemmour have 120 vote
	And VoteBlanc have 60 vote
	Then Macron have à score of 35%
	And Le Pen have à score of 10%
	And Mélanchon have à score of 5%
	And Zemmour have à score of 30%
	And VoteBlanc have à score of 15%
	When Score is equal or more than 50%
	And Score of VoteBlanc equal or more than 35%
	Then is to mutch VoteBlanc the election winner is cancel false
	And winner is noone
	When second turn with Macron and Zemmour 
	Given Macron have 100 vote		
	And Zemmour have 80 vote
	And VoteBlanc have 20 vote
	Then Macron have à score of 50%
	And Zemmour have à score of 40%
	And VoteBlanc have à score of 10%
	When Score of VoteBlanc equal or more than 35%
	Then scond turn winner is Macron
	And is to mutch VoteBlanc the election winner is cancel false

	Scenario: On prend en compte les votes blanc au 2eme tours si il est >35%
	Given Macron have 140 vote
	And Le Pen have 40 vote
	And Mélanchon have 20 vote
	And Zemmour have 120 vote
	And VoteBlanc have 60 vote
	Then Macron have à score of 35%
	And Le Pen have à score of 10%
	And Mélanchon have à score of 5%
	And Zemmour have à score of 30%
	And VoteBlanc have à score of 15%
	When Score is equal or more than 50%
	And Score of VoteBlanc equal or more than 35%
	Then is to mutch VoteBlanc the election winner is cancel false
	And winner is noone
	When second turn with Macron and Zemmour 
	Given Macron have 70 vote		
	And Zemmour have 50 vote
	And VoteBlanc have 80 vote
	Then Macron have à score of 35%
	And Zemmour have à score of 25%
	And VoteBlanc have à score of 40%
	When Score of VoteBlanc equal or more than 35%
	Then scond turn winner is noone
	And is to mutch VoteBlanc the election winner is cancel true