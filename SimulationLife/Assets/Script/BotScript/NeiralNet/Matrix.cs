using System;									   

namespace NeiralNet {
	/// <summary> 
	/// Класс с методом умножения матриц 
	/// </summary>
	static class Matrix {
		/// <summary> Умножение двух матриц </summary>
		/// <param name="A">ссылка на матрицу</param>
		/// <param name="B">ссылка на матрицу</param>
		/// <returns>матрица С = A * B</returns>
		static public float [,] Multiplication(float [,] A, float [,] B) {
			try {
				int Am = A.GetLength( 1 ), Bn = B.GetLength( 0 ), An = A.GetLength( 0 ), Bm = B.GetLength( 1 );
				if (Am != Bn)
					throw new Exception();
				float [,] C = new float [ An, Bm ];
				for (int i = 0 ; i < An ; ++i)
					for (int j = 0 ; j < Bm ; ++j)
						for (int k = 0 ; k < Am ; ++k) {
							C [ i, j ] += A [ i, k ] * B [ k, j ];
						}
				return C;
			}
			catch {																																																												
				return null;
			}
		}
	}
}