using System.Collections;
using System.Collections.Generic;

public interface GameProceedingStrategy {

	void Save(GameData gameData);

	GameData Load();

	void RemoveSavedGame();
}
