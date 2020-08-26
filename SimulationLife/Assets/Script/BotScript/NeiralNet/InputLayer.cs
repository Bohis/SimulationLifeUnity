using System;

namespace NeiralNet {
	/// <summary> 
	/// Класс, входного слоя нейросети 
	/// </summary>	
	class InputLayer : NeuralComponets {
		///<summary> 
		///Конструктор, с заданием кол-ва столбов 
		///</summary>
		public InputLayer(int m) {
			_m = m;
			_n = 1;
			_matrix = new float[ _n, _m ];
		}
		///<summary> 
		///Чтение из хеш-строки действий 
		///</summary>
		public void InputDate(float [] hashArray) {
			for (int j = 0; j < _m; ++j)
				Matrix[ 0, j ] = hashArray[ j];
		}
	}
}