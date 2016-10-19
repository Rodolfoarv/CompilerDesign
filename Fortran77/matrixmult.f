      program matrix

      real a(2,2),b(2,2),c(2,2)
      integer i,j

!     We will only use the upper 3 by 3 part of this array

      do 40 j = 1,2
        do 50 i = 1, 2
          a(i,j) = real(i+j)
          b(i,j) = real(i+j+2)
50      continue
40    continue
      write (*,*) a
      write (*,*) b

      call mm (a,b,c)
      write (*,*) c
      stop
      end


!     Subroutine execution
      subroutine mm(a,b,c)
      real a(2,2), b(2,2), c(2,2)


!     Local variables
      integer i,j,k
      real sum

      do 10 i = 1, 2
        do 20 j = 1, 2
          sum = 0.0
          do 30 k = 1, 2
            sum =  sum + a(i,k) * b(k,j)
30        continue
          c(i,j) = sum
20      continue
10    continue


      return
      end
