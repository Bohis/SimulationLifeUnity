using System;

namespace NeiralNet {
	/// <summary> 
	/// Класс, скрытого слоя нейросети 
	/// </summary> 
	class HiddenLayer : NeuralComponets {
		///<summary> 
		///Конструктор, с заданием кол-ва столбов 
		///</summary>
		public HiddenLayer(int m) {
			_m = m;
			_n = 1;
			_matrix = new float [ _n, _m ];
		}
		///<summary> 
		///Прогнать все значения через активационную функкцию 
		///</summary>
		public void Formalize() {
			for (int j = 0 ; j < _m ; ++j)
				_matrix [ 0, j ] = (float)Function.Sigmoid( _matrix [ 0, j ] );
		}
	}
}