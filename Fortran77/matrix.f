      program matrix

      real a(3,5)
      integer i,j

!     We will only use the upper 3 by 3 part of this array

      do 20 j = 1,3
        do 10 i = 1, 3
          a(i,j) = real(i) / real(j)
          write(*,*) 'value = ', a(i,j)
10      continue
20    continue



      stop
      end
