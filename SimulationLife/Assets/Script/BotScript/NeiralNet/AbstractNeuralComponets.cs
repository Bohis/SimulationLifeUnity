namespace NeiralNet {
	///<sumarry> 
	///Абстрактный класс, для компонетов нейронной сети 
	///</sumarry>
	abstract class NeuralComponets {
		///<sumarry> 
		///Матрица весов компонента 
		///</sumarry>
		protected float [,] _matrix;
		///<summary> 
		///Размеры матрицы 
		///</summary>
		protected int _n, _m;
		///<summary> 
		///Чтение кол-ва строк 
		///</summary>
		public int N {
			get { return _n; }
		}
		///<summary> 
		///Чтение кол-ва столбов 
		///</summary>
		public int M {
			get { return _m; }
		}
		/// <summary>
		///  Чтение матрицы весов
		/// </summary>
		public float [,] Matrix {
			get { return _matrix; }
			set { _matrix = value; }
		}
	}
}