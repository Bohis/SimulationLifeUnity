using System;

namespace NeiralNet {
	/// <summary> 
	/// Класс, выходного слоя нейросети 
	/// </summary>
	class OutputLayer : NeuralComponets {
		///<summary> 
		///Конструктор с заданием кол-ва столбов 
		///</summary>
		public OutputLayer(int m) {
			_m = m;
			_n = 1;
			_matrix = new float [ _n, _m ];
		}
		///<summary> 
		///Фомирование хеш-строки из полученных значений 
		///</summary>
		public float[,] OutputDate() {
			return _matrix;
		}
		///<summary> 
		///Прогон всех значений через активационную функцию 
		///</summary>
		public void Formalize() {		
			for (int j = 0 ; j < _m ; ++j)
				_matrix [ 0, j ] = (float)Function.Sigmoid( _matrix [ 0, j ] );
		}
	}
}