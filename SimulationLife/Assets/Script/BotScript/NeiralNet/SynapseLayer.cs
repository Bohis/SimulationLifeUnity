using System;

namespace NeiralNet {
	/// <summary> 
	/// Класс синапса нейросети 
	/// </summary>							
	class SynapseLayer : NeuralComponets {
		///<summary> 
		///Конструктор с заданием кол-во строк и кол-ва столбов 
		///</summary>
		public SynapseLayer(int n, int m) {
			System.Random ForSpace = new System.Random( DateTime.Now.Millisecond + DateTime.Now.Second + DateTime.Now.Minute + DateTime.Now.Hour);
			_m = m;
			_n = n;
			Matrix = new float [ _n, _m ];
			for (int i = 0 ; i < _n ; ++i)
				for (int j = 0 ; j < _m ; ++j)
					_matrix [ i, j ] = ForSpace.Next( -10, 10 ) ;
		}
		///<summary> 
		///Метод для формирования синапсов через наследования ботов 
		///</summary>
		public SynapseLayer(float [,] baseMatrix, int trainigCoof, bool triggerTrain) {
			System.Random ForSpace = new System.Random( DateTime.Now.Millisecond + DateTime.Now.Second + DateTime.Now.Minute + DateTime.Now.Hour );
			_m = baseMatrix.GetLength( 1 );
			_n = baseMatrix.GetLength( 0 );
			Matrix = new float [ _n, _m ];

			for (int i = 0 ; i < _n ; ++i)
				for (int j = 0 ; j < _m ; ++j) {
					_matrix [ i, j ] = baseMatrix [ i, j ];
					if (triggerTrain) {
						_matrix[i,j] += ForSpace.Next( -trainigCoof, trainigCoof );
					}															  
				}
		}
	}
}